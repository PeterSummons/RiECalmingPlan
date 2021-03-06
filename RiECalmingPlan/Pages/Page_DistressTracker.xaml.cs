﻿using RiECalmingPlan.Models;
using RiECalmingPlan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiECalmingPlan.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_DistressTracker : ContentPage {

        private readonly DistressLevelViewModel ViewModel = new DistressLevelViewModel();

        public Page_DistressTracker() {
            InitializeComponent();
            Carousel.BindingContext = ViewModel;

        }

        public void LevelButtonPressed(object sender, EventArgs e) {
            if (Label_DistressLevel.Text.ToString() == "Distress Level: Acute")
                Frame_SupportPlan.BackgroundColor = (Color)Application.Current.Resources["Distress_Red"];
            if (Label_DistressLevel.Text.ToString() == "Distress Level: Moderate")
                Frame_SupportPlan.BackgroundColor = (Color)Application.Current.Resources["Distress_Orange"];
            if (Label_DistressLevel.Text.ToString() == "Distress Level: Mild")
                Frame_SupportPlan.BackgroundColor = (Color)Application.Current.Resources["Distress_Yellow"];
            if (Label_DistressLevel.Text.ToString() == "Distress Level: Calm")
                Frame_SupportPlan.BackgroundColor = (Color)Application.Current.Resources["Distress_Green"];
            Carousel.Position = 1;
        }

        public void BackButtonPressed(object sender, EventArgs e) {
            Frame_SupportPlan.BackgroundColor = Color.White;
            Carousel.Position = 0;
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            ViewModel.StopTimer();
        }

    }
}