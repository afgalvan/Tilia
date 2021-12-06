using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Presentation.Windows;

namespace Presentation.Components.Medical.MedicalForms
{
    public partial class MedicalOrdersRegisterPage : Page
    {
        private readonly RegisterMedicalAppointmentUserControl _registerMedicalAppointment;
        private readonly MainWindow _mainWindow;

        public MedicalOrdersRegisterPage(RegisterMedicalAppointmentUserControl registerMedicalAppointment, MainWindow mainWindow)
        {
            _registerMedicalAppointment = registerMedicalAppointment;
            _mainWindow = mainWindow;
            InitializeComponent();
            Loaded += OnLoadedPage;
        }

        private void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.MedicalOrderItemButton.CurrentFormItemColors();
        }

        private void GoBackToPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.NavigateTo(_registerMedicalAppointment.MedicalNoteRegisterPage);
            _registerMedicalAppointment.MedicalOrderItemButton.DefaultFormItemColors();
        }

        private void FinishPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.MedicalOrderItemButton.CompletedFormItemColors();
        }
    }
}
