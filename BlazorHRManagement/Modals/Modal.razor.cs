using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorHRManagement.Modals
{
    public partial class Modal
    {
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        private void Submit() => MudDialog.Close(DialogResult.Ok(true));

        private void Cancel() => MudDialog.Cancel();
    }
}