
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AccidentTableComponent } from './accident-table/accident-table.component';
import { StopcardTableComponent } from './stopcard-table/stopcard-table.component';
import { ReportAccidentComponent } from './report-accident/report-accident.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccidentFormComponent } from './accident-form/accident-form.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { StopcardComponent } from './stopcard/stopcard.component';
import { StopCardReportComponent } from './stop-card-report/stop-card-report.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProfileComponent } from './profile/profile.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { JMPFormComponent } from './jmpform/jmpform.component';
import { JMPReportComponent } from './jmpreport/jmpreport.component';
import { JMPTableComponent } from './jmptable/jmptable.component';
import { EditAccidentComponent } from './edit-accident/edit-accident.component';
import { AddAccidentCausesComponent } from './add-accident-causes/add-accident-causes.component';
import { AccidentCausesComponent } from './accident-causes/accident-causes.component';
import { AddClassificationComponent } from './add-classification/add-classification.component';
import { ClassificationsComponent } from './classifications/classifications.component';
import { AddclassificationOfAccdComponent } from './addclassification-of-accd/addclassification-of-accd.component';
import { ClassificationOfAccidentComponent } from './classification-of-accident/classification-of-accident.component';
import { ComminucationMethodComponent } from './comminucation-method/comminucation-method.component';
import { AddComminucationMethodComponent } from './add-comminucation-method/add-comminucation-method.component';
import { AddDriverComponent } from './add-driver/add-driver.component';
import { DriverComponent } from './driver/driver.component';
import { AddPassengersComponent } from './add-passengers/add-passengers.component';
import { PassengersComponent } from './passengers/passengers.component';
import { AddPreventionCategoriesComponent } from './add-prevention-categories/add-prevention-categories.component';
import { PreventionCategoriesComponent } from './prevention-categories/prevention-categories.component';
import { AddQHSEPositionsComponent } from './add-qhsepositions/add-qhsepositions.component';
import { QHSEPositionsComponent } from './qhsepositions/qhsepositions.component';
import { AddQHSENamesComponent } from './add-qhsenames/add-qhsenames.component';
import { QHSENamesComponent } from './qhsenames/qhsenames.component';
import { AddReportedByNamesComponent } from './add-reported-by-names/add-reported-by-names.component';
import { ReportedByNamesComponent } from './reported-by-names/reported-by-names.component';
import { AddReportedByPositionsComponent } from './add-reported-by-positions/add-reported-by-positions.component';
import { ReportedByPositionsComponent } from './reported-by-positions/reported-by-positions.component';
import { AddRigsComponent } from './add-rigs/add-rigs.component';
import { RigsComponent } from './rigs/rigs.component';
import { AddRouteNamesComponent } from './add-route-names/add-route-names.component';
import { RouteNamesComponent } from './route-names/route-names.component';
import { AddToolPusherPositionsComponent } from './add-tool-pusher-positions/add-tool-pusher-positions.component';
import { ToolPusherPositionsComponent } from './tool-pusher-positions/tool-pusher-positions.component';
import { AddToolPusherNamesComponent } from './add-tool-pusher-names/add-tool-pusher-names.component';
import { ToolPusherNamesComponent } from './tool-pusher-names/tool-pusher-names.component';
import { AddTypeofInjuriesComponent } from './add-typeof-injuries/add-typeof-injuries.component';
import { TypeofInjuriesComponent } from './typeof-injuries/typeof-injuries.component';
import { AddTypeofObserviationComponent } from './add-typeof-observiation/add-typeof-observiation.component';
import { TypeofObserviationComponent } from './typeof-observiation/typeof-observiation.component';
import { AddVehiclesComponent } from './add-vehicles/add-vehicles.component';
import { VehiclesComponent } from './vehicles/vehicles.component';
import { AddViolationCategoriesComponent } from './add-violation-categories/add-violation-categories.component';
import { ViolationCategoriesComponent } from './violation-categories/violation-categories.component';
import { EditStopCardComponent } from './edit-stop-card/edit-stop-card.component';
import { EditAccidentCausesComponent } from './edit-accident-causes/edit-accident-causes.component';
import { EditClassificationComponent } from './edit-classification/edit-classification.component';
import { EditClassificationOfAccidentComponent } from './edit-classification-of-accident/edit-classification-of-accident.component';
import { EditComminucationMethodComponent } from './edit-comminucation-method/edit-comminucation-method.component';
import { EditDriverComponent } from './edit-driver/edit-driver.component';
import { EditPassengerComponent } from './edit-passenger/edit-passenger.component';
import { EditPreventionCategoryComponent } from './edit-prevention-category/edit-prevention-category.component';
import { EditQHSEPositionComponent } from './edit-qhseposition/edit-qhseposition.component';
import { EditQHSEPositionNameComponent } from './edit-qhseposition-name/edit-qhseposition-name.component';
import { EditReportedByNameComponent } from './edit-reported-by-name/edit-reported-by-name.component';
import { EditReportedByPositionComponent } from './edit-reported-by-position/edit-reported-by-position.component';
import { EditRigComponent } from './edit-rig/edit-rig.component';
import { EditRouteNameComponent } from './edit-route-name/edit-route-name.component';
import { EditToolPusherPositionComponent } from './edit-tool-pusher-position/edit-tool-pusher-position.component';
import { EditToolPusherPositionNameComponent } from './edit-tool-pusher-position-name/edit-tool-pusher-position-name.component';
import { EditTypeOfInjuryComponent } from './edit-type-of-injury/edit-type-of-injury.component';
import { EditTypeOfObservationCategoryComponent } from './edit-type-of-observation-category/edit-type-of-observation-category.component';
import { EditVehicleComponent } from './edit-vehicle/edit-vehicle.component';
import { EditViolationCategoryComponent } from './edit-violation-category/edit-violation-category.component';
import { EditJMLFormComponent } from './edit-jmlform/edit-jmlform.component';
import { AuthGuard } from './auth.guard';
import { ChangepasswordComponent } from './changepassword/changepassword.component';
import { StopCardChartComponent } from './stop-card-chart/stop-card-chart.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { RadioauthGuard } from './radioauth.guard';
import { UserauthGuard } from './userauth.guard';
import { ArrivalStatusSJPComponent } from './arrival-status-sjp/arrival-status-sjp.component';
import { StopCardCompareChartComponent } from './stop-card-compare-chart/stop-card-compare-chart.component';
import { HeathComponent } from './heath/heath.component';
import { SafetyComponent } from './safety/safety.component';
import { EnvironmentComponent } from './environment/environment.component';
import { QualityComponent } from './quality/quality.component';
import { ClincFormsComponent } from './clinc-forms/clinc-forms.component';
import { QSHEFormsComponent } from './qsheforms/qsheforms.component';
import { PolicyComponent } from './policy/policy.component';
import { AddRigMovePerformanceEvaluationComponent } from './add-rig-move-performance-evaluation/add-rig-move-performance-evaluation.component';
import { EditRigMovePerformanceEvaluationComponent } from './edit-rig-move-performance-evaluation/edit-rig-move-performance-evaluation.component';
import { RigMovePerformanceEvaluationComponent } from './rig-move-performance-evaluation/rig-move-performance-evaluation.component';
import { PrintRigPerformanceComponent } from './print-rig-performance/print-rig-performance.component';
import { RigPerformanceChartComponent } from './rig-performance-chart/rig-performance-chart.component';
import { SubDashboardComponent } from './sub-dashboard/sub-dashboard.component';
import { RigPerformanceCompareChartsComponent } from './rig-performance-compare-charts/rig-performance-compare-charts.component';
import { AllAuthGuardGuard } from './all-auth-guard.guard';
import { AddPTSMComponent } from './add-ptsm/add-ptsm.component';
import { PTSMComponent } from './ptsm/ptsm.component';
import { EditPTSMComponent } from './edit-ptsm/edit-ptsm.component';
import { PrintPTSMComponent } from './print-ptsm/print-ptsm.component';
import { BOPComponent } from './bop/bop.component';
import { EditBOPComponent } from './edit-bop/edit-bop.component';
import { BopTableComponent } from './bop-table/bop-table.component';
import { PrintBopComponent } from './print-bop/print-bop.component';

const routes: Routes = [
  { path: '', redirectTo: '/Login', pathMatch: 'full' },
  { path: 'Login', component: LoginComponent },
  { path: 'Register',canActivate: [AuthGuard],  component: RegisterComponent },
  { path: 'Notifications', canActivate: [AuthGuard], component: NotificationsComponent },
  { path: 'ArrivalStatusSJP',canActivate: [AllAuthGuardGuard], component: ArrivalStatusSJPComponent },
  { path: 'Dashboard/Accidents',canActivate: [AllAuthGuardGuard],component: AccidentTableComponent },
  { path: 'Home',canActivate: [AllAuthGuardGuard], component: HomeComponent },
  { path: 'Accident', canActivate: [UserauthGuard],component: AccidentFormComponent },
  { path: 'Accident/Edit/:id', canActivate: [AuthGuard],component: EditAccidentComponent },
  { path: 'StopCard/Edit/:id', canActivate: [UserauthGuard],component: EditStopCardComponent },
  { path: 'SJP/Edit/:id', canActivate: [AllAuthGuardGuard],component: EditJMLFormComponent },
  { path: 'Dashboard/AccidentCauses/Add',canActivate: [UserauthGuard], component: AddAccidentCausesComponent },
  { path: 'Dashboard/AccidentCauses/Edit/:id', canActivate: [AuthGuard],component: EditAccidentCausesComponent },
  { path: 'Dashboard/AccidentCauses',canActivate: [UserauthGuard], component: AccidentCausesComponent },
  { path: 'Dashboard/ClassificationOfAccident/Add', canActivate: [UserauthGuard],component: AddclassificationOfAccdComponent },
  { path: 'Dashboard/ClassificationOfAccident/Edit/:id',canActivate: [AuthGuard], component: EditClassificationOfAccidentComponent },
  { path: 'Dashboard/ClassificationOfAccident',canActivate: [UserauthGuard], component: ClassificationOfAccidentComponent },
  { path: 'Dashboard/ComminucationMethod/Add',canActivate: [UserauthGuard], component: AddComminucationMethodComponent },
  { path: 'Dashboard/ComminucationMethod/Edit/:id',canActivate: [AuthGuard], component: EditComminucationMethodComponent },
  { path: 'Dashboard/ComminucationMethod', canActivate: [UserauthGuard],component: ComminucationMethodComponent },
  { path: 'Dashboard/Driver/Add',canActivate: [AllAuthGuardGuard], component: AddDriverComponent },
  { path: 'Dashboard/Driver/Edit/:id', canActivate: [RadioauthGuard],component: EditDriverComponent },
  { path: 'Dashboard/Driver',canActivate: [AllAuthGuardGuard],component: DriverComponent },
  { path: 'Dashboard/Passenger/Add',canActivate: [UserauthGuard],component: AddPassengersComponent },
  { path: 'Dashboard/Passenger/Edit/:id',canActivate: [AuthGuard], component: EditPassengerComponent },
  { path: 'Dashboard/Passenger',canActivate: [UserauthGuard], component: PassengersComponent },
  { path: 'Dashboard/PreventionCategory/Add',canActivate: [UserauthGuard], component: AddPreventionCategoriesComponent },
  { path: 'Dashboard/PreventionCategory/Edit/:id',canActivate: [AuthGuard], component: EditPreventionCategoryComponent },
  { path: 'Dashboard/PreventionCategory', canActivate: [UserauthGuard],component: PreventionCategoriesComponent },
  { path: 'Dashboard/QHSEPosition/Add', canActivate: [UserauthGuard],component: AddQHSEPositionsComponent },
  { path: 'Dashboard/QHSEPosition/Edit/:id',canActivate: [AuthGuard], component: EditQHSEPositionComponent },
  { path: 'Dashboard/QHSEPosition',canActivate: [UserauthGuard], component: QHSEPositionsComponent },
  { path: 'Dashboard/QHSEPositionName/Add',canActivate: [UserauthGuard],component: AddQHSENamesComponent },
  { path: 'Dashboard/QHSEPositionName/Edit/:id',canActivate: [AuthGuard], component: EditQHSEPositionNameComponent },
  { path: 'Dashboard/QHSEPositionName',canActivate: [UserauthGuard],component: QHSENamesComponent },
  { path: 'Dashboard/ReportedByName/Add',canActivate: [UserauthGuard],component: AddReportedByNamesComponent },
  { path: 'Dashboard/ReportedByName/Edit/:id' ,canActivate: [AuthGuard],component: EditReportedByNameComponent },
  { path: 'Dashboard/ReportedByName',canActivate: [UserauthGuard],component: ReportedByNamesComponent },
  { path: 'Dashboard/ReportedByPosition/Add' ,canActivate: [UserauthGuard],component: AddReportedByPositionsComponent },
  { path: 'Dashboard/ReportedByPosition/Edit/:id',canActivate: [AuthGuard], component: EditReportedByPositionComponent },
  { path: 'Dashboard/ReportedByPosition',canActivate: [UserauthGuard], component: ReportedByPositionsComponent },
  { path: 'Dashboard/Rig/Add' ,canActivate: [UserauthGuard],component: AddRigsComponent },
  { path: 'Dashboard/Rig/Edit/:id' ,canActivate: [AuthGuard],component: EditRigComponent },
  { path: 'Dashboard/Rig', canActivate: [UserauthGuard],component: RigsComponent },
  { path: 'Dashboard/RouteName/Add' ,canActivate: [AllAuthGuardGuard],component: AddRouteNamesComponent },
  { path: 'Dashboard/RouteName/Edit/:id',canActivate: [RadioauthGuard], component: EditRouteNameComponent },
  { path: 'Dashboard/RouteName',canActivate: [AllAuthGuardGuard], component: RouteNamesComponent },
  { path: 'Dashboard/ToolPusherPosition/Add',canActivate: [UserauthGuard], component: AddToolPusherPositionsComponent },
  { path: 'Dashboard/ToolPusherPosition/Edit/:id',canActivate: [AuthGuard], component: EditToolPusherPositionComponent },
  { path: 'Dashboard/ToolPusherPosition',canActivate: [UserauthGuard],component: ToolPusherPositionsComponent },
  { path: 'Dashboard/ToolPusherPositionName/Add', canActivate: [UserauthGuard],component: AddToolPusherNamesComponent },
  { path: 'Dashboard/ToolPusherPositionName/Edit/:id',canActivate: [AuthGuard], component: EditToolPusherPositionNameComponent },
  { path: 'Dashboard/ToolPusherPositionName',canActivate: [UserauthGuard],component: ToolPusherNamesComponent },
  { path: 'Dashboard/TypeOfInjury/Add',canActivate: [UserauthGuard], component: AddTypeofInjuriesComponent },
  { path: 'Dashboard/TypeOfInjury/Edit/:id', canActivate: [AuthGuard],component: EditTypeOfInjuryComponent },
  { path: 'Dashboard/TypeOfInjury', canActivate: [UserauthGuard],component: TypeofInjuriesComponent },
  { path: 'Dashboard/TypeOfObserviationCategory/Add',canActivate: [UserauthGuard], component: AddTypeofObserviationComponent },
  { path: 'Dashboard/TypeOfObserviationCategory/Edit/:id',canActivate: [AuthGuard], component: EditTypeOfObservationCategoryComponent },
  { path: 'Dashboard/TypeOfObserviationCategory',canActivate: [UserauthGuard], component: TypeofObserviationComponent },
  { path: 'Dashboard/Vehicle/Add',canActivate: [AllAuthGuardGuard],component: AddVehiclesComponent },
  { path: 'Dashboard/Vehicle/Edit/:id', canActivate: [RadioauthGuard],component: EditVehicleComponent },
  { path: 'Dashboard/Vehicle',canActivate: [AllAuthGuardGuard], component: VehiclesComponent },
  { path: 'Dashboard/ViolationCategory/Add',canActivate: [UserauthGuard], component: AddViolationCategoriesComponent },
  { path: 'Dashboard/ViolationCategory/Edit/:id', canActivate: [AuthGuard],component: EditViolationCategoryComponent },
  { path: 'Dashboard/ViolationCategory',canActivate: [UserauthGuard], component: ViolationCategoriesComponent },
  { path: 'Dashboard/Classification/Add' ,canActivate: [UserauthGuard],component: AddClassificationComponent },
  { path: 'Dashboard/Classification/Edit/:id',canActivate: [AuthGuard], component: EditClassificationComponent },
  { path: 'Dashboard/Classification',canActivate: [UserauthGuard], component: ClassificationsComponent },
  { path: 'Dashboard/PTSM',canActivate: [UserauthGuard], component: PTSMComponent },
  { path: 'Dashboard/PTSM/Add' ,canActivate: [UserauthGuard],component: AddPTSMComponent },
  { path: 'Dashboard/PTSM/Edit/:id',canActivate: [AuthGuard], component: EditPTSMComponent },

  { path: 'Dashboard/BOP',canActivate: [UserauthGuard], component: BOPComponent },
  { path: 'Dashboard/BOP/Add' ,canActivate: [UserauthGuard],component:BOPComponent  },
   { path: 'Dashboard/BOP/Edit/:id',canActivate: [AuthGuard], component: EditBOPComponent },
  { path: 'PrintBOP', canActivate: [UserauthGuard],component: PrintBopComponent },


  { path: 'PrintAccident',canActivate: [UserauthGuard], component: ReportAccidentComponent },
  { path: 'StopCard', canActivate: [UserauthGuard],component: StopcardComponent },
  { path: 'PrintStopCard', canActivate: [UserauthGuard],component: StopCardReportComponent },
  { path: 'PrintPTSM', canActivate: [UserauthGuard],component: PrintPTSMComponent },
  { path: 'Dashboard/Stopcard',canActivate: [UserauthGuard],component: StopcardTableComponent },
  { path: 'AccidentTable', canActivate: [UserauthGuard],component: AccidentTableComponent },
  { path: 'BopTable', canActivate: [UserauthGuard],component: BopTableComponent },
  { path: 'Dashboard' ,canActivate: [UserauthGuard],component: DashboardComponent },
  { path: 'SubDashboard' ,canActivate: [AllAuthGuardGuard],component: SubDashboardComponent },
  { path: 'Profile',canActivate: [AllAuthGuardGuard], component: ProfileComponent },
  { path: 'Health',canActivate: [UserauthGuard], component: HeathComponent },
  { path: 'Safety',canActivate: [UserauthGuard], component: SafetyComponent },
  { path: 'Environment',canActivate: [UserauthGuard], component: EnvironmentComponent },
  { path: 'Quality',canActivate: [UserauthGuard], component: QualityComponent },
  { path: 'AboutUs',canActivate: [AllAuthGuardGuard], component: ContactUsComponent },
  { path: 'SJP',canActivate: [AllAuthGuardGuard], component: JMPFormComponent },
  { path: 'PrintSJP',canActivate: [AllAuthGuardGuard], component: JMPReportComponent },
  { path: 'Dashboard/SJPTable',canActivate: [AllAuthGuardGuard], component: JMPTableComponent },
  { path: 'changepassword',canActivate: [AllAuthGuardGuard],component: ChangepasswordComponent },
  { path: 'stopCardCharts' ,canActivate: [UserauthGuard],component: StopCardChartComponent },
  { path: 'RigMovePerformanceCharts' ,canActivate: [UserauthGuard],component: RigPerformanceChartComponent },
  { path: 'stopCardCompareCharts' ,canActivate: [UserauthGuard],component: StopCardCompareChartComponent },
  { path: 'RigMovePerformanceCompareCharts' ,canActivate: [UserauthGuard],component: RigPerformanceCompareChartsComponent },
  { path: 'RigPerformance/Add' ,canActivate: [UserauthGuard],component: AddRigMovePerformanceEvaluationComponent },
  { path: 'RigPerformance/Edit/:id' ,canActivate: [UserauthGuard],component: EditRigMovePerformanceEvaluationComponent },
  { path: 'RigPerformance' ,canActivate: [UserauthGuard],component: RigMovePerformanceEvaluationComponent },
  { path: 'PrintRigPerformance' ,canActivate: [UserauthGuard],component: PrintRigPerformanceComponent },
  { path: 'Clinc' ,canActivate: [UserauthGuard],component: ClincFormsComponent },
  { path: 'QHSE' ,canActivate: [UserauthGuard],component: QSHEFormsComponent },
  { path: 'Policy' ,canActivate: [UserauthGuard],component: PolicyComponent },


  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
