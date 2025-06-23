using DeviceControl.Wpf.ViewModels;
using GenICam;
using GenICam.Interfaces;
using GigeVision.Core.Interfaces;
using GigeVision.Core.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DeviceControl.Test.Wpf.ViewModels;

public class MainWindowViewModel : BindableBase
{
    private string _title = "DeviceControl Test";
    private XmlHelper xmlHelper;

    public List<ICategory> DebugCategories { get; set; }

    public string Title
    {
        get { return _title; }
        set { SetProperty(ref _title, value); }
    }

    public DeviceControlViewModel DeviceControl { get; set; }
    public ICamera Camera { get; }

    public MainWindowViewModel()
    {
        DeviceControl = new DeviceControlViewModel("192.168.100.70");
        DeviceControl.Gvcp.SaveXmlFileFromCamera(@"C:\Users\MoralityCore\Documents\Mircea Rimbu\TestBench\GigeVision\C6");

        // Debug

        Task.Run(async () =>
        {
            try
            {
                await DeviceControl.Gvcp.ReadAllRegisterAddressFromCameraAsync().ConfigureAwait(false);
                DebugCategories = DeviceControl.Gvcp.CategoryDictionary;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        });


        // End Debug

    }

}