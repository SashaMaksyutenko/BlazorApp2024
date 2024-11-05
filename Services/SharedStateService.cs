using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BlazorApp2024.Services
{
    public class SharedStateService
    {
        public event Action OnChange;
		private int _totalCartCount;
		public int TotalCartCount
		{
			get => _totalCartCount;
			set
			{
				_totalCartCount = value;
				NotifyStateChanged();
			}
		}
		private void NotifyStateChanged() => OnChange?.Invoke();
    }
}