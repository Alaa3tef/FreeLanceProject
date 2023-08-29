import { Time } from '@angular/common';

export interface IJMP {
  id: number;
  company: string;
  speedLimit: number,
  distance: number,
  journyNumber: number;
  date: Date;
  destination: string;
  purposeOfJourny: string;
  reachBeforeDark: string;
  communicationID: number;
  journyManagerName: string;
  managerNumber: string;
  driverNameId: number;
  departureDate: Date;
  vehicleId: number;
  estimatedArriveDate: Date;
  estimatedArriveTime: Time;
  restLocationNames: string;
  routeNameID: number;
  inspectionVechile: string;
  status: string;
  nightDrivingReason: string;
  qhseManagerMustApprove: string;
  licenceNumber: string;
  licenceExpireDate: Date;
  enterTime: Date;

  passengerName1:string;
  passengerName2:string;
  passengerName3:string;
  passengerName4:string;

  passengerPhone1:string;
  passengerPhone2:string;
  passengerPhone3:string;
  passengerPhone4:string;

}
