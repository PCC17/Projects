using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;

namespace MobileApp
{
    [Activity(Label = "MobileApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private SeekBar sekRed;
        private SeekBar sekGreen;
        private SeekBar sekBlue;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            sekRed = FindViewById<SeekBar>("skbRed");
            sekGreen = FindViewById<SeekBar>("sekGreen");
            sekBlue = FindViewById<SeekBar>("sekBlue");

            sekRed.SetOnSeekBarChangeListener(new OnSeekBarChangeListener(){
            {

                @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub

            }

            @Override
            public void onStartTrackingTouch 
            (SeekBar seekBar)
            {
                // TODO Auto-generated method stub

            }

            @Override
            public void onProgressChanged  (SeekBar seekBar, int progress,bool fromUser)
            {
                // TODO Auto-generated method stub



                //Change the int value of the doBrightness from here?
            }
        }
        });
    }
       

       
    }
}

