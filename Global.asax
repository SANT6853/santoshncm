<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
     public override void Init()
    {
        this.PostAuthenticateRequest +=
            new EventHandler(MyOnPostAuthenticateRequestHandler);
        base.Init();
    }
    
    private void MyOnPostAuthenticateRequestHandler(object sender, EventArgs e)
    {
        if (FormsAuthentication.CookiesSupported == true)
        {

            HttpCookie formAuthCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (formAuthCookie != null)
            {
                //Decrypt the cookie value.  
                FormsAuthenticationTicket formAuthTicket = FormsAuthentication.Decrypt(formAuthCookie.Value);
                System.Web.Script.Serialization.JavaScriptSerializer objSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                //Deserialize the cookie value  
                CustomPrincipalSerializer serializeModel = objSerializer.Deserialize<CustomPrincipalSerializer>(formAuthTicket.UserData);
                MyCustomPrincipal newUser = new MyCustomPrincipal(formAuthTicket.Name);
               newUser.Id = serializeModel.Id;
                newUser.UserName = serializeModel.UserName;
                //newUser.IsAdmin = serializeModel.IsAdmin;
               newUser.UserType = serializeModel.UserType;
               // newUser.Modules = serializeModel.Modules;
                //Save details in the httpcontext  
                HttpContext.Current.User = newUser;
            }
        }
    }
    protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
    {
    }
    static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.MapPageRoute("index", "index", "~/index.aspx");
    }  
       
</script>
