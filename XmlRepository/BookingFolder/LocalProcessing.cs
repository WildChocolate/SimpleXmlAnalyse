using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlRepository.BookingFolder
{
    public class LocalProcessing
    {
        public string DeliveryRequiredBy { get; set; }

        public string EstimatedDelivery { get; set; }

        public string EstimatedPickup { get; set; }

        public FCLDeliveryEquipmentNeeded FCLDeliveryEquipmentNeeded { get; set; }

        public FCLPickupEquipmentNeeded FCLPickupEquipmentNeeded { get; set; }

        public string InsuranceRequired { get; set; }

        public string PickupRequiredBy { get; set; }

    }
}
