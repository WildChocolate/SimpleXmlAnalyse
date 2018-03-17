using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ShipmentFolder
{
    public class LocalProcessing
    {
        public string ArrivalCartageRef { get; set; }

        public string DeliveryCartageAdvised { get; set; }

        public string DeliveryCartageCompleted { get; set; }

        public string DeliveryLabourCharge { get; set; }

        public string DeliveryLabourTime { get; set; }

        public string DeliveryRequiredBy { get; set; }

        public string DemurrageOnDeliveryCharge { get; set; }

        public string DemurrageOnDeliveryTime { get; set; }

        public string DemurrageOnPickupCharge { get; set; }

        public string DemurrageOnPickupTime { get; set; }

        public string EstimatedDelivery { get; set; }

        public string EstimatedPickup { get; set; }

        public ExportStatement ExportStatement { get; set; }

        public string FCLAvailable { get; set; }

        public FCLDeliveryEquipmentNeeded FCLDeliveryEquipmentNeeded { get; set; }

        public FCLPickupEquipmentNeeded FCLPickupEquipmentNeeded { get; set; }

        public string FCLStorageCommences { get; set; }

        public string HasProhibitedPackaging { get; set; }

        public string InsuranceRequired { get; set; }

        public string IsContingencyRelease { get; set; }

        public string LCLAirStorageCharge { get; set; }

        public string LCLAirStorageDaysOrHours { get; set; }

        public string LCLAvailable { get; set; }

        public string LCLDatesOverrideConsol { get; set; }

        public string LCLStorageCommences { get; set; }

        public string PickupCartageAdvised { get; set; }

        public string PickupCartageCompleted { get; set; }

        public string PickupLabourCharge { get; set; }

        public string PickupLabourTime { get; set; }

        public string PickupRequiredBy { get; set; }

        public PrintOptionForPackagesOnAWB PrintOptionForPackagesOnAWB { get; set; }

        public List<OrderNumber> OrderNumberCollection { get; set; }
        public List<AdditionalService> AdditionalServiceCollection { get; set; }
    }
}
