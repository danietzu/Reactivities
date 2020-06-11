using Microsoft.AspNetCore.Components;
using System;

namespace Client.Store
{
    public class UserViewModelBase : ComponentBase, IDisposable
    {
        [Inject]
        public UserViewModel Model { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Model.PropertyChanged += Model_PropertyChanged;
            }
            base.OnAfterRender(firstRender);
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InvokeAsync(() => StateHasChanged());
        }

        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Model.PropertyChanged -= Model_PropertyChanged;
                }

                _disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
    }
}