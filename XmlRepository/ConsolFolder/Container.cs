using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ConsolFolder
{
    public class Container
    {
        public string AirVentFlow { get; set; }

        public AirVentFlowRateUnit AirVentFlowRateUnit { get; set; }

        public string ArrivalCartageAdvised { get; set; }

        public string ArrivalCartageComplete { get; set; }

        public string ArrivalCartageDemurrageCharge { get; set; }

        public string ArrivalCartageDemurrageTime { get; set; }

        public string ArrivalCartageRef { get; set; }

        public string ArrivalDeliveryRequiredBy { get; set; }

        public string ArrivalEstimatedDelivery { get; set; }

        public string ArrivalPickupByRail { get; set; }

        public string ArrivalSlotDateTime { get; set; }

        public string ArrivalSlotReference { get; set; }

        public Commodity Commodity { get; set; }

        public string ContainerCount { get; set; }

        public string ContainerDetentionCharge { get; set; }

        public string ContainerDetentionDays { get; set; }

        public string ContainerImportDORelease { get; set; }

        public string ContainerNumber { get; set; }

        public string ContainerParkEmptyPickupGateOut { get; set; }

        public string ContainerParkEmptyReturnGateIn { get; set; }

        public ContainerQuality ContainerQuality { get; set; }

        public ContainerStatus ContainerStatus { get; set; }

        public ContainerType ContainerType { get; set; }

        public string DeliveryMode { get; set; }

        public string DeliverySequence { get; set; }

        public string DepartureCartageAdvised { get; set; }

        public string DepartureCartageComplete { get; set; }

        public string DepartureCartageDemurrageCharge { get; set; }

        public string DepartureCartageDemurrageTime { get; set; }

        public string DepartureCartageRef { get; set; }

        public string DepartureDeliveryByRail { get; set; }

        public string DepartureDockReceipt { get; set; }

        public string DepartureEstimatedPickup { get; set; }

        public string DepartureSlotDateTime { get; set; }

        public string DepartureSlotReference { get; set; }

        public string DunnageWeight { get; set; }

        public string EmptyReadyForReturn { get; set; }

        public string EmptyRequired { get; set; }

        public string EmptyReturnedBy { get; set; }

        public string ExportDepotCustomsReference { get; set; }

        public FCL_LCL_AIR FCL_LCL_AIR { get; set; }

        public string FCLAvailable { get; set; }

        public string FCLHeldInTransitStaging { get; set; }

        public string FCLOnBoardVessel { get; set; }

        public string FCLStorageArrivedUnderbond { get; set; }

        public string FCLStorageCharge { get; set; }

        public string FCLStorageCommences { get; set; }

        public string FCLStorageDays { get; set; }

        public string FCLStorageModuleOnlyMaster { get; set; }

        public string FCLStorageUnderbondCleared { get; set; }

        public string FCLUnloadFromVessel { get; set; }

        public string FCLWharfGateIn { get; set; }

        public string FCLWharfGateOut { get; set; }

        public string GoodsValue { get; set; }

        public GoodsValueCurrency GoodsValueCurrency { get; set; }

        public string GoodsWeight { get; set; }

        public string GrossWeight { get; set; }

        public GrossWeightVerificationType GrossWeightVerificationType { get; set; }

        public string HumidityPercent { get; set; }

        public string IsCFSRegistered { get; set; }

        public string IsControlledAtmosphere { get; set; }

        public string IsDamaged { get; set; }

        public string IsEmptyContainer { get; set; }

        public string IsSealOk { get; set; }

        public string IsShipperOwned { get; set; }

        public string LCLAvailable { get; set; }

        public string LCLStorageCommences { get; set; }

        public string LCLUnpack { get; set; }

        public LengthUnit LengthUnit { get; set; }

        public string Link { get; set; }

        public string OverhangBack { get; set; }

        public string OverhangFront { get; set; }

        public string OverhangHeight { get; set; }

        public string OverhangLeft { get; set; }

        public string OverhangRight { get; set; }

        public string OverrideFCLAvailableStorage { get; set; }

        public string OverrideLCLAvailableStorage { get; set; }

        public string PackDate { get; set; }

        public string RefrigGeneratorID { get; set; }

        public string ReleaseNum { get; set; }

        public string Seal { get; set; }

        public SealPartyType SealPartyType { get; set; }

        public string SecondSeal { get; set; }

        public SecondSealPartyType SecondSealPartyType { get; set; }

        public string SetPointTemp { get; set; }

        public string SetPointTempUnit { get; set; }

        public string StowagePosition { get; set; }

        public string TareWeight { get; set; }

        public string TempRecorderSerialNo { get; set; }

        public string ThirdSeal { get; set; }

        public ThirdSealPartyType ThirdSealPartyType { get; set; }

        public string TotalHeight { get; set; }

        public string TotalLength { get; set; }

        public string TotalWidth { get; set; }

        public string TrainWagonNumber { get; set; }

        public string UnpackGang { get; set; }

        public string UnpackShed { get; set; }

        public string VolumeCapacity { get; set; }

        public VolumeUnit VolumeUnit { get; set; }

        public string WeightCapacity { get; set; }

        public WeightUnit WeightUnit { get; set; }

    }
}
