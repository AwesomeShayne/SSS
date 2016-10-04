using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SOSQL;



namespace SSS
{
    public class Organizer
    {
        private Container ShippingContainer;
        private List<MedicalDevice> Devices;
        private List<Supply> Supplies;

        public Organizer(Container _ShippingContainers, List<MedicalDevice> _Devices, List<Supply> _Supplies)
        {
            ShippingContainer = _ShippingContainers;
            Devices = _Devices;
            Supplies = _Supplies;
            DetermineTotalVolume();
        }

        
    }
}
