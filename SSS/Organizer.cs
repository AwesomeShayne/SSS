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
        private List<Container> InternalContainers;
        private List<MedicalDevice> Devices;
        private float DeviceVolume;
        private List<Supply> Supplies;
        private int ContainerCount = 0;
        private List<String> Steps = new List<string>();

        public Organizer(Container _ShippingContainers, List<MedicalDevice> _Devices, List<Supply> _Supplies)
        {
            ShippingContainer = _ShippingContainers;
            Devices = _Devices;
            Supplies = _Supplies;
            DetermineContainerCount();
        }

        private void DetermineContainerCount()
        {
            float _DeviceVolume = 0;
            foreach (MedicalDevice _Device in Devices)
            {
                var _volume = _Device.Volume - _Device.ContainerVolumes;
                _DeviceVolume += _volume;
            }
            DeviceVolume = _DeviceVolume;
            foreach (Supply _Supply in Supplies)
            {
                _DeviceVolume += _Supply.Box.ExternalVolume;
            }
            while (_DeviceVolume > 0)
            {
                ContainerCount += 1;
                if (_DeviceVolume > ShippingContainer.InternalVolume)
                    _DeviceVolume -= ShippingContainer.InternalVolume;
                else
                    _DeviceVolume = 0;
            }
        }

        public void DeterminePackingOrder() // Needs to define the proper return value
        {
            float _RemainingVolume = ShippingContainer.InternalVolume - DeviceVolume;
            Container _SmallerContainer = null;// SQL QUery for all Containers; Grab the largest one;
            while (_RemainingVolume > _SmallerContainer.InternalVolume)
            {
                InternalContainers.Add(_SmallerContainer);
                _RemainingVolume -= _SmallerContainer.InternalVolume;
            }
            Devices = Devices.OrderBy(o => o.Volume).ToList();
            InternalContainers = InternalContainers.OrderBy(o =>o.ExternalVolume).ToList();
            Supplies = Supplies.OrderBy(o => o.Box.ExternalVolume).ToList();
            
        }

        private Container PackStep(Container _ThisContainer, List<MedicalDevice> _Devices, List<Container>
            _InternalContainers, List<Supply> _Supplies, out Container _NextStepContainer,out List<MedicalDevice> 
            _OutDevices, out List<Container> _OutInternalContainers, out List<Supply> _OutSupplies)
        {
            List<float> _Volumes = new List<float>();
            _Volumes.Add(_InternalContainers[0].ExternalVolume);
            _Volumes.Add(_Devices[0].Volume);
            _Volumes.Add(_Supplies[0].Box.ExternalVolume);
            if (Steps.Count() == 0)
            {
                if (_Volumes[0] > _Volumes[1] && _Volumes[0] > _Volumes[2] && _ThisContainer.CanStackZ() > _InternalContainers[0].Weight)
                {
                    Steps.Add(""); // TODO: Determine the add message, this also ties in with return value
                    Pack(InternalContainers[0], Devices, Supplies);
                    _InternalContainers.RemoveAt(0);
                }
                else if (_Volumes[1] > _Volumes[2] && _Volumes[1] > _Volumes[0])
                {
                    Devices[0].DetermineBestShippingPosition();
                    Steps.Add("");
                    _Devices.RemoveAt(0);
                }
                else if (_Volumes[2] > _Volumes[1] && _Volumes[2] > _Volumes[0])
                {
                    Steps.Add("");
                    _Supplies.RemoveAt(0);
                }
            }
        }

        private void Pack(Container container, List<MedicalDevice> devices, List<Supply> supplies)
        {
            throw new NotImplementedException();
        }
    }
}
