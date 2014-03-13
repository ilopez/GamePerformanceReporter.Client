using GamePerformanceReporter;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GamePerfReporter
{
    public class WebApi
    {
        private string apibaseurl;
        private string apikey;       
        private RestClient c;

        public WebApi(String Key, String URL)
        {
            this.apikey = Key;
            this.apibaseurl = URL;
            this.c = new RestClient(apibaseurl);
            
        }

        public Report newReport(Report i)
        {
            return saveCreateReport(i,true);
        }

        private Report saveCreateReport(Report i, Boolean isNew)
        {

            Report ret = (Report)sendXMLObject("/v1/report/", i, (isNew ? Method.POST : Method.PUT ), 1000);
            if (ret == null)
            {
                return new Report();
            }
            else
            {
                return ret;
            }
        }

        public Report getReport(String id)
        {
            Dictionary<String, String> vars = new Dictionary<string, string>();
            vars.Add("{ID}", id);
            String path = "/v1/report/{ID}/";
            Report ret = new Report();
            ret = (Report)sendStringGetXMLObject(path,vars,ret.GetType(),Method.GET,1000);
            return ret;
        }

        public Report saveReport(Report i)
        {
            return saveCreateReport(i, false);
        }

        public Boolean uploadReportFile(ReportFile rf, byte[] data)
        {
            return false;
        }

        public Report testMirror(Report i)
        {
            Report ret = (Report)sendXMLObject("/v1/report/mirror", i, Method.POST, 100);
            if(ret == null)
            {
                return new Report();
            }else{
                return ret;
            }
        }

        public Boolean testPing()
        {
            String ret = "";

            try
            {
                var rq = createPlainRequest("/v1/ping/", Method.GET, 100);
                var rs = c.Execute(rq);
                if (rs.ResponseStatus == ResponseStatus.Completed && rs.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ret = rs.Content;
                }
            }
            catch
            {
                return false;
            }


            if (ret.Equals("pong"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private Object sendStringGetXMLObject(String path, Dictionary<String, String> variables, Type t, Method m, int timeout)
        {
            try
            {
                String newpath = replacePathStrings(path, variables);
                var r = createXMLRequest(newpath, m, timeout);
                var rr = c.Execute(r);
                if (rr.ResponseStatus == ResponseStatus.Completed && rr.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return xmlDeserialize(rr.Content, t);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private string replacePathStrings(string path, Dictionary<string, string> variables)
        {
            foreach (KeyValuePair<string, String> var in variables)
            {
                path.Replace(var.Key, var.Value);
            }
            return path;
        }

        private Object sendXMLObject(String path, Object i, Method m, int timeout)
        {
            try
            {
                var r = createXMLRequest(path, m, timeout);
                r.AddParameter("application/xml", xmlSerialize(i), ParameterType.RequestBody);

                var rr = c.Execute(r);

                if (rr.ResponseStatus == ResponseStatus.Completed && rr.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return xmlDeserialize(rr.Content, i.GetType() );
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }

        private RestRequest createXMLRequest(String path, Method m, int timeout)
        {
            var r = new RestRequest(path, m);
            r.AddHeader("Accept", "application/xml");
            r.AddHeader("X-API-Key", apikey);
            r.Timeout = timeout;
            return r;
        }

        private RestRequest createPlainRequest(String path, Method m, int timeout)
        {
            var r = new RestRequest(path, m);
            r.AddHeader("Accept", "*/*");            
            r.AddHeader("X-API-Key", apikey);
            r.Timeout = timeout;
            return r;
        }

        private String xmlSerialize(Object input)
        {
            XmlSerializer xs = new XmlSerializer( input.GetType() , String.Empty);
            MemoryStream ms = new MemoryStream();
            XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            xs.Serialize(xtw, input);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
        private Object xmlDeserialize(String input, Type t)
        {
            XmlSerializer xs = new XmlSerializer(t, String.Empty);
            StringReader sr = new StringReader(input);
            XmlTextReader xtr = new XmlTextReader(sr);
            return xs.Deserialize(xtr);
        }


    }
}
