<%@ WebHandler Language="C#" Class="Resource" %>

using System;
using System.Web;
using R = WebResources.Resource;

public class Resource : IHttpHandler {

    public void ProcessRequest(HttpContext context) {
        context.Response.ContentType = "text/text";
        object[] oo = null;
        try
        {
            string name = context.Request.Params[null];
            oo = R.GetResource(name);
            string mimeType = (string)oo[0];
            byte[] fileContents = (byte[]) oo[1];
            context.Response.ContentType = mimeType;
            context.Response.Headers["Content-Disposition"] = "attachment; filename = \"" + name + "\"";
            context.Response.BinaryWrite(fileContents);
            return;
        }
        catch(Exception ex)
        {
            context.Response.Write(ex.Message + "\r\n" + ex.StackTrace);
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}