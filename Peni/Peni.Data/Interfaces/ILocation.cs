using System;
using System.Threading.Tasks;

namespace Peni.Data
{
	public interface ILocation
	{
		Task<double> GetLat();
		Task<double> GetLng();
	}
}

