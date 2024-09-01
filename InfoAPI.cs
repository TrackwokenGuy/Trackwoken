using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static DeepwokenChecklist.InfoAPI;

namespace DeepwokenChecklist
{
    public class ReqFrom
    {
        public string talent;
        public string other;
    }

    public class Requirements
    {
        public int power;
        public int[] attributes;
        public ReqFrom from;

        public int SumOfAttributes()
        {
            return attributes.Sum();
        }
    }

    public class Talent
    {
        public string name;
        public Requirements requirements;
        public bool obtained = false;
    }

    public struct Build
    {
        public Dictionary<string, Talent> talents;
    }

    internal static class InfoAPI
    {
        const string APIURL = "https://api.deepwoken.co/";

        struct SkeletonBuild
        {
            public string[] mantras;
            public string[] talents;
        }
        
        public static Dictionary<string, Talent> Talents;

        public static void Load()
        {
            LoadTalents();
        }

        static void LoadTalents()
        {
            Talents = new Dictionary<string, Talent>();
            var response = Request("get?type=talent&name=all");

            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new StreamReader(response.GetResponseStream(), encoding))
            {
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(reader.ReadToEnd());
                var content = (data["content"] as JObject).ToObject<Dictionary<string, Dictionary<string, object>>>();

                foreach(KeyValuePair<string, Dictionary<string, object>> kvp in content)
                {
                    var talentData = kvp.Value;

                    Talent talent = new Talent();

                    talent.name = (string)talentData["name"];

                    var reqData = (talentData["reqs"] as JObject).ToObject<Dictionary<string, object>>();
                    Requirements requirements = new Requirements();
                    requirements.power = int.Parse((string)reqData["power"]);

                    var jobjectIndividualAttrData = reqData.Skip(2);
                    var attrData = new Dictionary<string, int>();
                    
                    foreach(KeyValuePair<string, object> attributeType in jobjectIndividualAttrData)
                    {
                        var attributes = (attributeType.Value as JObject).ToObject<Dictionary<string, int>>();
                        foreach (KeyValuePair<string, int> attributeData in attributes)
                        {
                            attrData.Add(attributeData.Key, attributeData.Value);
                        }
                    }

                    requirements.attributes = attrData.Values.ToArray();

                    requirements.from = new ReqFrom() { other = (string)reqData["from"] };

                    talent.requirements = requirements;

                    Talents.Add(talent.name, talent);
                }

            }

            // Fix requirements
            foreach(Talent talent in Talents.Values)
            {
                var from = talent.requirements.from.other;
                if (Talents.ContainsKey(from))
                {
                    talent.requirements.from.talent = from;
                    talent.requirements.from.other = "";
                }
            }
            
        }

        
        static SkeletonBuild GetBuildStructure(string URL)
        {
            SkeletonBuild build = new SkeletonBuild();

            var response = Request(URL);
            
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new StreamReader(response.GetResponseStream(), encoding))
            {
                string responseText = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseText);
                var content = (data["content"] as JObject).ToObject<Dictionary<string, object>>();
                build.talents = (content["talents"] as JArray).ToObject<string[]>();
                
            }

            return build;
        }

        public static Build GetBuild(string URL)
        {
            SkeletonBuild skeleton = GetBuildStructure(URL);

            Build build = new Build();
            Dictionary<string, Talent> talents = new Dictionary<string, Talent>();
            foreach (string talent in skeleton.talents)
            {
                talents.Add(talent, Talents[talent]);
            }

            build.talents = talents;
            return build;
        }

        static WebResponse Request(string URL)
        {
            var request = HttpWebRequest.Create(APIURL + URL);
            return request.GetResponse();
        }
    }
}
