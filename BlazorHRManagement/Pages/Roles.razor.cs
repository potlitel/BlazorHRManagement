using Entities;

namespace BlazorHRManagement.Pages
{
    public partial class Roles
    {
        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private Roles selectedItem1 = null!;
        private HashSet<Role> selectedItems = new();

        private IEnumerable<Role> roles = new List<Role>();

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var respuestaHttp = await repo.Get<List<Role>>("employees");
            roles = respuestaHttp.Response!;
        }
    }
}