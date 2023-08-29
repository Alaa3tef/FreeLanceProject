import { IViolationCategory } from './../SharedClasses/IViolationCategory';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { IAccident } from 'SharedClasses/IAccident';
import { IAccidentCauses } from 'SharedClasses/IAccidentCauses';
import { IAPIResult } from 'SharedClasses/IAPIResult';
import { IClassification } from 'SharedClasses/IClassification';
import { IClassificationOfAccident } from 'SharedClasses/IClassificationOfAccident';
import { IComminucationMethod } from 'SharedClasses/IComminucationMethod';
import { IDriver } from 'SharedClasses/IDriver';
import { IJMP } from 'SharedClasses/IJMP';
import { IPassenger } from 'SharedClasses/IPassenger';
import { IPreventionCategory } from 'SharedClasses/IPreventionCategory';
import { IQHSEPosition } from 'SharedClasses/IQHSEPosition';
import { IQHSEPositionName } from 'SharedClasses/IQHSEPositionName';
import { IReportedByName } from 'SharedClasses/IReportedByName';
import { IReportedByPosition } from 'SharedClasses/IReportedByPosition';
import { IRig } from 'SharedClasses/IRig';
import { IRigMovePerformanceEvaluation } from 'SharedClasses/IRigMovePerformanceEvaluation';
import { IRouteName } from 'SharedClasses/IRouteName';
import { IStopCardRegister } from 'SharedClasses/IStopCardRegister';
import { IToolPusherPosition } from 'SharedClasses/IToolPusherPosition';
import { IToolPusherPositionName } from 'SharedClasses/IToolPusherPositionName';
import { ITypeOfInjury } from 'SharedClasses/ITypeOfInjury';
import { ITypeOfObservationCategory } from 'SharedClasses/ITypeOfObservationCategory';
import { IVehicle } from 'SharedClasses/IVehicle';

@Injectable({
  providedIn: 'root'
})
export class DeleteDataService {

  
  constructor(private http:HttpClient) { }


  // DeleteAccidents(Accident:IAccident): Observable<IAccident> {
  //   return this.http.put<IAccident>(`http://localhost:5000/api/Accident/Delete/${Accident.id}`,Accident);
  // }

  DeleteDrivers(Driver:IDriver): Observable<IDriver> {
    return this.http.put<IDriver>(`http://localhost:5000/api/Driver/Delete/${Driver.id}`,Driver);
  }
   

  DeleteViolationcCategories(ViolationCategory:IViolationCategory): Observable<IViolationCategory> {
    return this.http.put<IViolationCategory>(`http://localhost:5000/api/ViolationCategory/Delete/${ViolationCategory.id}`,ViolationCategory);
  }

  DeleteVehicles(Vehicle:IVehicle): Observable<IVehicle> {
    return this.http.put<IVehicle>(`http://localhost:5000/api/Vehicle/Delete/${Vehicle.id}`,Vehicle);
  }

  DeleteTypeOfObservationCategory(TypeOfObservationCategory:ITypeOfObservationCategory): Observable<ITypeOfObservationCategory> {
    return this.http.put<ITypeOfObservationCategory>(`http://localhost:5000/api/TypeOfObservationCategory/Delete/${TypeOfObservationCategory.id}`,TypeOfObservationCategory);
  }


  DeleteTypeOfInjury(TypeOfInjury:ITypeOfInjury): Observable<ITypeOfInjury> {
    return this.http.put<ITypeOfInjury>(`http://localhost:5000/api/TypeOfInjury/Delete/${TypeOfInjury.id}`,TypeOfInjury);
  }

  DeleteToolPusherPosition(ToolPusherPosition:IToolPusherPosition): Observable<IToolPusherPosition> {
    return this.http.put<IToolPusherPosition>(`http://localhost:5000/api/ToolPusherPosition/Delete/${ToolPusherPosition.id}`,ToolPusherPosition);
  }

  DeleteToolPusherPositionName(ToolPusherPositionName:IToolPusherPositionName): Observable<IToolPusherPositionName> {
    return this.http.put<IToolPusherPositionName>(`http://localhost:5000/api/ToolPusherPositionName/Delete/${ToolPusherPositionName.id}`,ToolPusherPositionName);
  }

  DeleteStopCard(StopCardRegister:IStopCardRegister): Observable<IStopCardRegister> {
    return this.http.put<IStopCardRegister>(`http://localhost:5000/api/StopCardRegister/Delete/${StopCardRegister.id}`,StopCardRegister);
  }

  DeleteRoutName(RouteName:IRouteName): Observable<IRouteName> {
    return this.http.put<IRouteName>(`http://localhost:5000/api/RouteName/Delete/${RouteName.id}`,RouteName);
  }

  DeleteRig(Rig:IRig): Observable<IRig> {
    return this.http.put<IRig>(`http://localhost:5000/api/Rig/Delete/${Rig.id}`,Rig);
  }

  DeleteReportedByPosition(ReportedByPosition:IReportedByPosition): Observable<IReportedByPosition> {
    return this.http.put<IReportedByPosition>(`http://localhost:5000/api/ReportedByPosition/Delete/${ReportedByPosition.id}`,ReportedByPosition);
  }

  DeleteReportedByName(ReportedByName:IReportedByName): Observable<IReportedByName> {
    return this.http.put<IReportedByName>(`http://localhost:5000/api/ReportedByName/Delete/${ReportedByName.id}`,ReportedByName);
  }

  DeleteQHSEPosition(QHSEPosition:IQHSEPosition): Observable<IQHSEPosition> {
    return this.http.put<IQHSEPosition>(`http://localhost:5000/api/QHSEPosition/Delete/${QHSEPosition.id}`,QHSEPosition);
  }

  DeleteQHSEPositionName(QHSEPositionName:IQHSEPositionName): Observable<IQHSEPositionName> {
    return this.http.put<IQHSEPositionName>(`http://localhost:5000/api/QHSEPositionName/Delete/${QHSEPositionName.id}`,QHSEPositionName);
  }

  DeletePreventionCategory(PreventionCategory:IPreventionCategory): Observable<IPreventionCategory> {
    return this.http.put<IPreventionCategory>(`http://localhost:5000/api/PreventionCategory/Delete/${PreventionCategory.id}`,PreventionCategory);
  }

  DeletePassenger(Passenger:IPassenger): Observable<IPassenger> {
    return this.http.put<IPassenger>(`http://localhost:5000/api/Passenger/Delete/${Passenger.id}`,Passenger);
  }

  DeleteJMP(JMP:IJMP): Observable<IJMP> {
    return this.http.put<IJMP>(`http://localhost:5000/api/JMP/Delete/${JMP.id}`,JMP);
  }

  DeleteCommuncationMethod(ComminucationMethod:IComminucationMethod): Observable<IComminucationMethod> {
    return this.http.put<IComminucationMethod>(`http://localhost:5000/api/ComminucationMethod/Delete/${ComminucationMethod.id}`,ComminucationMethod);
  }

  DeleteClassification(Classification:IClassification): Observable<IClassification> {
    return this.http.put<IClassification>(`http://localhost:5000/api/Classification/Delete/${Classification.id}`,Classification);
  }

  DeleteClassificationOfAccident(ClassificationOfAccident:IClassificationOfAccident): Observable<IClassificationOfAccident> {
    return this.http.put<IClassificationOfAccident>(`http://localhost:5000/api/ClassificationOfAccident/Delete/${ClassificationOfAccident.id}`,ClassificationOfAccident);
  }

  DeleteAccident(Accident:IAccident): Observable<IAccident> {
    return this.http.put<IAccident>(`http://localhost:5000/api/Accident/Delete/${Accident.id}`,Accident);
  }

  DeleteAccidentCauses(AccidentCauses:IAccidentCauses): Observable<IAccidentCauses> {
    return this.http.put<IAccidentCauses>(`http://localhost:5000/api/AccidentCauses/Delete/${AccidentCauses.id}`,AccidentCauses);
  }


  DeleteRigPerformance(RigPerformance:IRigMovePerformanceEvaluation): Observable<IRigMovePerformanceEvaluation> {
    return this.http.put<IRigMovePerformanceEvaluation>(`http://localhost:5000/api/RigMovePerformance/Delete/${RigPerformance.id}`,RigPerformance);
  }
}

