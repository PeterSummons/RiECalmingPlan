﻿using RiECalmingPlan.Models.JSON;
using RiECalmingPlan.PhotoPicker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiECalmingPlan.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_NewDiaryEntry : ContentPage {

        public event EventHandler SaveHandler;
        public event EventHandler UpdateHandler;
        public string EntryType = "New";

        public Page_NewDiaryEntry() {
            InitializeComponent();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e) {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null) {
                image.Source = ImageSource.FromStream(() => stream);
                /*
                 * At this point we need to save the path from whichever photo that was selected to the PhotoLink field in the model.
                 * 
                 * The current problem here is converting the image source (Which is a stream object) to a tangible URI or file link so it
                 * can be saved to the JSON file.
                 * This is why you can select an image and display it when creating or editing an entry, but does not persist as the link isn't saved
                 * 
                 */
            }

            (sender as Button).IsEnabled = true;

        }

        async void OnCameraPhotoButtonClicked(object sender, EventArgs e) {
            /*
             * Function kept here but does not work as of yet.
             */
        }

        async void OnSaveButtonClicked(object sender, EventArgs e) {
            if (EntryType.Equals("New")) {
                SaveHandler(this.BindingContext, EventArgs.Empty);
            } else {
                UpdateHandler(this.BindingContext, EventArgs.Empty);
            }
            await Navigation.PopAsync();
        }
    }
}