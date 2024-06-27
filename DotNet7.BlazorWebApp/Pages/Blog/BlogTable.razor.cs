using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DotNet7.BlazorWebApp.Pages.Blog
{
    public partial class BlogTable
    {
        string[] rows =
        {
            @"1 Krishna kpartner0@usatoday.com Male 28.25.250.202",
            @"2 Webb wstitle1@ning.com Male 237.168.134.114",
            @"3 Nathanil nneal2@cyberchimps.com Male 92.6.0.175",
            @"4 Adara alockwood3@patch.com Female 182.174.217.152",
            @"5 Cecilius cchaplin4@shinystat.com Male 195.124.144.18",
            @"6 Cicely cemerine9@soup.io Female 138.94.191.43",
        };

        string state = "Message box hasn't been opened yet";


        private async void OnButtonClicked()
        {
            var options = new DialogOptions
            {
                CloseOnEscapeKey = true,
                FullWidth = true,
                MaxWidth = MaxWidth.ExtraSmall,
                ClassBackground = "my-custom-class"
            };
            bool? result = await DialogService.ShowMessageBox(
                "Warning",
                "Deleting can not be undone!",
                yesText: "Delete!", cancelText: "Cancel", options: options);
            state = result == null ? "Canceled" : "Deleted!";
            StateHasChanged();
        }
    }
}