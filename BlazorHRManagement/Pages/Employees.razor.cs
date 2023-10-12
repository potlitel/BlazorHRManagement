using BlazorHRManagement.Modals;
using CurrieTechnologies.Razor.SweetAlert2;
using Entities;
using MudBlazor;

namespace BlazorHRManagement.Pages
{
    public partial class Employees
    {
        private bool dense = true;
        private bool hover = true;
        private bool striped = true;
        private bool bordered = false;
        private bool _loading = true;
        private string searchString1 = "";
        private Employee selectedItem1 = null!;
        private HashSet<Employee> selectedItems = new();

        private IEnumerable<Employee> employees = new List<Employee>();

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var respuestaHttp = await repo.Get<List<Employee>>("employees");
            employees = respuestaHttp.Response!;
            _loading = false;
        }

        private async Task DeleteRol(Employee item)
        {
            var resultado = await swal.FireAsync(
                new SweetAlertOptions
                {
                    Title = "Confirmación",
                    Text = $"Desea eliminar el empleado {item.employee_name}?",
                    ShowCancelButton = true,
                    Icon = SweetAlertIcon.Warning
                }
            );

            var confirmado = !string.IsNullOrEmpty(resultado.Value);

            if (confirmado)
            {
                var respuestaHttp = await repo.Delete($"employees/{item.employee_id}");

                if (respuestaHttp.Error)
                {
                    if (
                        respuestaHttp.HttpResponseMessage.StatusCode
                        == System.Net.HttpStatusCode.NotFound
                    )
                    {
                        navigationManager.NavigateTo("roles");
                    }
                    else
                    {
                        var msgError = await respuestaHttp.ObtenerMensajeError();
                        await swal.FireAsync("Error", msgError, SweetAlertIcon.Error);
                    }
                }
                else
                {
                    await LoadData();
                }
            }
        }

        private bool FilterFunc1(Employee element) => FilterFunc(element, searchString1);

        private bool FilterFunc(Employee element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            //if (element.Sign.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            //    return true;
            if (element.employee_name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            //if ($"{element.Number} {element.Position} {element.Molar}".Contains(searchString))
            //    return true;
            return false;
        }

        private void OpenDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            //Dialog.Show("Custom Options Dialog", options);
            DialogService.Show<ModalTest>("Simple Dialog", options);
        }
    }
}