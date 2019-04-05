﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AddressBook.Droid
{
    [MetaData("com.google.android.geo.API_KEY", Value = "AIzaSyAdU4gMmEX88mWbJyJ9zv0i_ar9uhCyJEU")]
    [Activity(Label = "AddressBook", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsGoogleMaps.Init(this,savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);   
            LoadApplication(new App());
        }
    }
}