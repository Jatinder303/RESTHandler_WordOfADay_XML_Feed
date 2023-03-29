using AndroidHUD;
using System.Net;

namespace RESTHandler_WordOfADay_XML_Feed
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        TextView txtword;
        TextView txtDescription;
        RESTHandler objRest;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            txtword = FindViewById<TextView>(Resource.Id.txtWord);
            txtDescription = FindViewById<TextView>(Resource.Id.txtDescription);
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            LoadTodaysWordAsync();
        }

        public async void LoadTodaysWordAsync()
        {
            AndHUD.Shared.Show(this, "Loading ...", 30);
            objRest = new RESTHandler(@"https://www.wordsmith.org/awad/rss1.xml");
            var Response = await objRest.ExecuteRequestAsync();
            txtword.Text = Response.Channel.Item.Title;
            txtDescription.Text = Response.Channel.Item.Description;
            AndHUD.Shared.Dismiss (this);
        }
    }
}