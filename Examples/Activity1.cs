
using Android.App;
using Android.Widget;
using Android.OS;
using Examples;

namespace ExampleAndroid
{
    [Activity(Label = "ExampleAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
                {
                    Program.Main(null);
                    button.Text = string.Format("{0} clicks!", count++);
                };
        }
    }
}

