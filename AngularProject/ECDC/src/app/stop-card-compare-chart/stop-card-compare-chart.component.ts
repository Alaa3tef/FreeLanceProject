import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { Chart, registerables } from 'chart.js';
import ChartDataLabels from 'chartjs-plugin-datalabels';
import { LoginService } from '../../../Services/login.service';
Chart.register(ChartDataLabels);
Chart.register(...registerables);

@Component({
  selector: 'app-stop-card-compare-chart',
  templateUrl: './stop-card-compare-chart.component.html',
  styleUrls: ['./stop-card-compare-chart.component.scss']
})
export class StopCardCompareChartComponent {
  clearChart(ID_Name:string) {
    const myElement = document.querySelector('#'+ ID_Name) as HTMLElement;
    myElement.remove()
    this.UnsafeAct_Month1 = [];
    this.UnsafeCondition_Month1 = [];
    this.PositiveRemark_Month1 = [];
    this.Other_Month1 = [];
    this.BypassingSafetyControls_Month1 = [];
    this.Driving_Month1 = [];
    this.EnergyIsolation_Month1 = [];
    this.HotWork_Month1 = [];
    this.LineofFire_Month1 = [];
    this.SafeMechanicalLifting_Month1 = [];
    this.WorkAuthorization_Month1 = [];
    this.WorkingatHeight_Month1 = [];
    this.PPE_Month1 = [];
    this.Housekeeping_Month1 = [];
    this.Environmental_Month1 = [];
    this.HealthCare_Month1 = [];
    this.SafetyProtectionSystem_Month1 = [];
    this.HSEIMS_Month1 = [];
    this.Equipment_Month1 = [];
    this.OtherCategory_Month1 = [];
    this.SWA_yes_Month1 = [];
    this.SWA_no_Month1 = [];
    this.UnsafeAct_Month2 = [];
    this.UnsafeCondition_Month2 = [];
    this.PositiveRemark_Month2 = [];
    this.Other_Month2 = [];
    this.BypassingSafetyControls_Month2 = [];
    this.Driving_Month2 = [];
    this.EnergyIsolation_Month2 = [];
    this.HotWork_Month2 = [];
    this.LineofFire_Month2 = [];
    this.SafeMechanicalLifting_Month2 = [];
    this.WorkAuthorization_Month2 = [];
    this.WorkingatHeight_Month2 = [];
    this.PPE_Month2 = [];
    this.Housekeeping_Month2 = [];
    this.Environmental_Month2 = [];
    this.HealthCare_Month2 = [];
    this.SafetyProtectionSystem_Month2 = [];
    this.HSEIMS_Month2 = [];
    this.Equipment_Month2 = [];
    this.OtherCategory_Month2 = [];
    this.SWA_yes_Month2 = [];
    this.SWA_no_Month2 = [];
    }

  AddCanvas(ID_Name:string,DIV_Name:string) {
    // Create a new element
    var newElement = document.createElement('canvas');
    newElement.id=ID_Name

    // Get the parent element where you want to append the new element
    const myElement = document.querySelector('#'+DIV_Name) as HTMLElement;

    // Append the new element to the parent element
    myElement.appendChild(newElement);
  }


  month1: number = 0;
  month2: number = 0;
  month1_Name: string = '';
  month2_Name: string = '';

  temp: boolean = false;
  classifications: string[] = [];
  categories: string[] = [];

  UnsafeAct_Month1: any[] = [];
  UnsafeActCount_Month1: number = 0;
  UnsafeCondition_Month1: any[] = [];
  UnsafeConditionCount_Month1: number = 0;
  PositiveRemark_Month1: any[] = [];
  PositiveRemarkCount_Month1: number = 0;
  Other_Month1: any[] = [];
  OtherCount_Month1: number = 0;
  BypassingSafetyControls_Month1: any[] = [];
  BypassingSafetyControlsCount_Month1: number = 0;
  Driving_Month1: any[] = [];
  DrivingCount_Month1: number = 0;
  EnergyIsolation_Month1: any[] = [];
  EnergyIsolationCount_Month1: number = 0;
  HotWork_Month1: any[] = [];
  HotWorkCount_Month1: number = 0;
  LineofFire_Month1: any[] = [];
  LineofFireCount_Month1: number = 0;
  SafeMechanicalLifting_Month1: any[] = [];
  SafeMechanicalLiftingCount_Month1: number = 0;
  WorkAuthorization_Month1: any[] = [];
  WorkAuthorizationCount_Month1: number = 0;
  WorkingatHeight_Month1: any[] = [];
  WorkingatHeightCount_Month1: number = 0;
  PPE_Month1: any[] = [];
  PPECount_Month1: number = 0;
  Housekeeping_Month1: any[] = [];
  HousekeepingCount_Month1: number = 0;
  Environmental_Month1: any[] = [];
  EnvironmentalCount_Month1: number = 0;
  HealthCare_Month1: any[] = [];
  HealthCareCount_Month1: number = 0;
  SafetyProtectionSystem_Month1: any[] = [];
  SafetyProtectionSystemCount_Month1: number = 0;
  HSEIMS_Month1: any[] = [];
  HSEIMSCount_Month1: number = 0;
  Equipment_Month1: any[] = [];
  EquipmentCount_Month1: number = 0;
  OtherCategory_Month1: any[] = [];
  OtherCategoryCount_Month1: number = 0;
  SWA_yes_Month1: any[] = [];
  SWA_yesCount_Month1: number = 0;
  SWA_no_Month1: any[] = [];
  SWA_noCount_Month1: number = 0;
  UnsafeAct_Month2: any[] = [];
  UnsafeActCount_Month2: number = 0;
  UnsafeCondition_Month2: any[] = [];
  UnsafeConditionCount_Month2: number = 0;
  PositiveRemark_Month2: any[] = [];
  PositiveRemarkCount_Month2: number = 0;
  Other_Month2: any[] = [];
  OtherCount_Month2: number = 0;
  BypassingSafetyControls_Month2: any[] = [];
  BypassingSafetyControlsCount_Month2: number = 0;
  Driving_Month2: any[] = [];
  DrivingCount_Month2: number = 0;
  EnergyIsolation_Month2: any[] = [];
  EnergyIsolationCount_Month2: number = 0;
  HotWork_Month2: any[] = [];
  HotWorkCount_Month2: number = 0;
  LineofFire_Month2: any[] = [];
  LineofFireCount_Month2: number = 0;
  SafeMechanicalLifting_Month2: any[] = [];
  SafeMechanicalLiftingCount_Month2: number = 0;
  WorkAuthorization_Month2: any[] = [];
  WorkAuthorizationCount_Month2: number = 0;
  WorkingatHeight_Month2: any[] = [];
  WorkingatHeightCount_Month2: number = 0;
  PPE_Month2: any[] = [];
  PPECount_Month2: number = 0;
  Housekeeping_Month2: any[] = [];
  HousekeepingCount_Month2: number = 0;
  Environmental_Month2: any[] = [];
  EnvironmentalCount_Month2: number = 0;
  HealthCare_Month2: any[] = [];
  HealthCareCount_Month2: number = 0;
  SafetyProtectionSystem_Month2: any[] = [];
  SafetyProtectionSystemCount_Month2: number = 0;
  HSEIMS_Month2: any[] = [];
  HSEIMSCount_Month2: number = 0;
  Equipment_Month2: any[] = [];
  EquipmentCount_Month2: number = 0;
  OtherCategory_Month2: any[] = [];
  OtherCategoryCount_Month2: number = 0;
  SWA_yes_Month2: any[] = [];
  SWA_yesCount_Month2: number = 0;
  SWA_no_Month2: any[] = [];
  SWA_noCount_Month2: number = 0;

  User:any;

  constructor(private loginService:LoginService,private dataService: DataService) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.User=this.loginService.currentUser.getValue();
    this.dataService.GetClassification().subscribe({
      next: data => {
        data.data.forEach((element: { name: string; }) => {
          this.classifications.push(element.name)
        });
      }
    })
    this.dataService.GetTypeOfObservationCategory().subscribe({
      next: data => {
        data.data.forEach((element: { name: string; }) => {
          this.categories.push(element.name)
        });
      }
    })
  }


  onMonth1Change(event: any) {
    this.month1 = event.target.value
    const myComboBox = document.getElementById('month1') as HTMLSelectElement;
    const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    const selectedText = selectedOption.text;
    this.month1_Name = selectedText
  }

  onMonth2Change(event: any) {
    this.month2 = event.target.value
    const myComboBox = document.getElementById('month2') as HTMLSelectElement;
    const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    const selectedText = selectedOption.text;
    this.month2_Name = selectedText
  }

  onChange(event: any) {
    console.log(this.month1)
    console.log(this.month2)
    console.log(this.month1_Name)
    console.log(this.month2_Name)
    this.temp = true;
    this.dataService.GetDataForChartsCompare(this.month1, this.month2,this.User.ID,this.User.Role).subscribe({
      next: data => {
        console.log(data.data)
        this.clearChart("myChart")
        data.data.forEach((element: { date: Date; classification: string; }) => {
          const validDate = new Date(element.date)

          // console.log(validDate.getMonth()+1)
          if (element.classification == 'Unsafe Act' && (validDate.getMonth() + 1) == this.month1) {
            this.UnsafeAct_Month1.push(element)
          }
          else if (element.classification == 'Unsafe Act' && (validDate.getMonth() + 1) == this.month2) {
            this.UnsafeAct_Month2.push(element)
          }
          else if (element.classification == 'Positive Remark' && (validDate.getMonth() + 1) == this.month1) {
            this.PositiveRemark_Month1.push(element)
          }
          else if (element.classification == 'Positive Remark' && (validDate.getMonth() + 1) == this.month2) {
            this.PositiveRemark_Month2.push(element)
          }
          else if (element.classification == 'Unsafe Condition' && (validDate.getMonth() + 1) == this.month1) {
            this.UnsafeCondition_Month1.push(element)
          }
          else if (element.classification == 'Unsafe Condition' && (validDate.getMonth() + 1) == this.month2) {
            this.UnsafeCondition_Month2.push(element)
          }
          else if (element.classification == 'Other' && (validDate.getMonth() + 1) == this.month1) {
            this.Other_Month1.push(element)
          }
          else if (element.classification == 'Other' && (validDate.getMonth() + 1) == this.month2) {
            this.Other_Month2.push(element)
          }
        });
        this.UnsafeActCount_Month1 = this.UnsafeAct_Month1.length
        this.UnsafeActCount_Month2 = this.UnsafeAct_Month2.length
        this.UnsafeConditionCount_Month1 = this.UnsafeCondition_Month1.length
        this.UnsafeConditionCount_Month2 = this.UnsafeCondition_Month2.length
        this.PositiveRemarkCount_Month1 = this.PositiveRemark_Month1.length
        this.PositiveRemarkCount_Month2 = this.PositiveRemark_Month2.length
        this.OtherCount_Month1 = this.Other_Month1.length
        this.OtherCount_Month2 = this.Other_Month2.length

        this.AddCanvas("myChart","chart1")

        var myChart = new Chart("myChart", {
          type: 'bar',
          data: {
            labels: this.classifications,
            datasets: [{
              label: this.month1_Name,
              data: [
                this.UnsafeActCount_Month1,
                this.UnsafeConditionCount_Month1,
                this.PositiveRemarkCount_Month1,
                this.OtherCount_Month1
              ],
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)'
                ],
                font: {
                  size: 18,
                }
              }
            }
            ,{
              label: this.month2_Name,
              data: [this.UnsafeActCount_Month2, this.UnsafeConditionCount_Month2, this.PositiveRemarkCount_Month2, this.OtherCount_Month2],
              backgroundColor: [
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)'
              ],
              borderColor: [
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)'
                ],
                font: {
                  size: 18,
                }
              }
            }
          ]
          },
          options: {
            scales: {
              y: {
                beginAtZero: true
              }
            }
          }
        });

      }
    })
    ///////////////////////////////////////////////////////////////////////////////////////
    this.dataService.GetDataForChartsCompare(this.month1, this.month2,this.User.ID,this.User.Role).subscribe({
      next: data => {
        console.log(data.data)
        this.clearChart("myChart2")
        data.data.forEach((element: { date: Date; typeOfObservationCategory: string; }) => {
          const validDate = new Date(element.date)

          // console.log(validDate.getMonth()+1)
          if (element.typeOfObservationCategory == 'Bypassing Safety Controls' && (validDate.getMonth() + 1) == this.month1) {
            this.BypassingSafetyControls_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Bypassing Safety Controls' && (validDate.getMonth() + 1) == this.month2) {
            this.BypassingSafetyControls_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Driving' && (validDate.getMonth() + 1) == this.month1) {
            this.Driving_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Driving' && (validDate.getMonth() + 1) == this.month2) {
            this.Driving_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Energy Isolation' && (validDate.getMonth() + 1) == this.month1) {
            this.EnergyIsolation_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Energy Isolation' && (validDate.getMonth() + 1) == this.month2) {
            this.EnergyIsolation_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Hot Work' && (validDate.getMonth() + 1) == this.month1) {
            this.HotWork_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Hot Work' && (validDate.getMonth() + 1) == this.month2) {
            this.HotWork_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Line of Fire' && (validDate.getMonth() + 1) == this.month1) {
            this.LineofFire_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Line of Fire' && (validDate.getMonth() + 1) == this.month2) {
            this.LineofFire_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Safe Mechanical Lifting' && (validDate.getMonth() + 1) == this.month1) {
            this.SafeMechanicalLifting_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Safe Mechanical Lifting' && (validDate.getMonth() + 1) == this.month2) {
            this.SafeMechanicalLifting_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Work Authorization' && (validDate.getMonth() + 1) == this.month1) {
            this.WorkAuthorization_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Work Authorization' && (validDate.getMonth() + 1) == this.month2) {
            this.WorkAuthorization_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Working at Height' && (validDate.getMonth() + 1) == this.month1) {
            this.WorkingatHeight_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Working at Height' && (validDate.getMonth() + 1) == this.month2) {
            this.WorkingatHeight_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'PPE' && (validDate.getMonth() + 1) == this.month1) {
            this.PPE_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'PPE' && (validDate.getMonth() + 1) == this.month2) {
            this.PPE_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Housekeeping' && (validDate.getMonth() + 1) == this.month1) {
            this.Housekeeping_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Housekeeping' && (validDate.getMonth() + 1) == this.month2) {
            this.Housekeeping_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Environmental' && (validDate.getMonth() + 1) == this.month1) {
            this.Environmental_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Environmental' && (validDate.getMonth() + 1) == this.month2) {
            this.Environmental_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Health Care' && (validDate.getMonth() + 1) == this.month1) {
            this.HealthCare_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Health Care' && (validDate.getMonth() + 1) == this.month2) {
            this.HealthCare_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Safety Protection System' && (validDate.getMonth() + 1) == this.month1) {
            this.SafetyProtectionSystem_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Safety Protection System' && (validDate.getMonth() + 1) == this.month2) {
            this.SafetyProtectionSystem_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'HSE IMS' && (validDate.getMonth() + 1) == this.month1) {
            this.HSEIMS_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'HSE IMS' && (validDate.getMonth() + 1) == this.month2) {
            this.HSEIMS_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Equipment' && (validDate.getMonth() + 1) == this.month1) {
            this.Equipment_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Equipment' && (validDate.getMonth() + 1) == this.month2) {
            this.Equipment_Month2.push(element)
          }
          else if (element.typeOfObservationCategory == 'Other' && (validDate.getMonth() + 1) == this.month1) {
            this.OtherCategory_Month1.push(element)
          }
          else if (element.typeOfObservationCategory == 'Other' && (validDate.getMonth() + 1) == this.month2) {
            this.OtherCategory_Month2.push(element)
          }
        });
        this.BypassingSafetyControlsCount_Month1 = this.BypassingSafetyControls_Month1.length
        this.BypassingSafetyControlsCount_Month2 = this.BypassingSafetyControls_Month2.length
        this.DrivingCount_Month1 = this.Driving_Month1.length
        this.DrivingCount_Month2 = this.Driving_Month2.length
        this.EnergyIsolationCount_Month1 = this.EnergyIsolation_Month1.length
        this.EnergyIsolationCount_Month2 = this.EnergyIsolation_Month2.length
        this.HotWorkCount_Month1 = this.HotWork_Month1.length
        this.HotWorkCount_Month2 = this.HotWork_Month2.length
        this.LineofFireCount_Month1 = this.LineofFire_Month1.length
        this.LineofFireCount_Month2 = this.LineofFire_Month2.length
        this.SafeMechanicalLiftingCount_Month1 = this.SafeMechanicalLifting_Month1.length
        this.SafeMechanicalLiftingCount_Month2 = this.SafeMechanicalLifting_Month2.length
        this.WorkAuthorizationCount_Month1 = this.WorkAuthorization_Month1.length
        this.WorkAuthorizationCount_Month2 = this.WorkAuthorization_Month2.length
        this.WorkingatHeightCount_Month1 = this.WorkingatHeight_Month1.length
        this.WorkingatHeightCount_Month2 = this.WorkingatHeight_Month2.length
        this.PPECount_Month1 = this.PPE_Month1.length
        this.PPECount_Month2 = this.PPE_Month2.length
        this.HousekeepingCount_Month1 = this.Housekeeping_Month1.length
        this.HousekeepingCount_Month2 = this.Housekeeping_Month2.length
        this.EnvironmentalCount_Month1 = this.Environmental_Month1.length
        this.EnvironmentalCount_Month2 = this.Environmental_Month2.length
        this.HealthCareCount_Month1 = this.HealthCare_Month1.length
        this.HealthCareCount_Month2 = this.HealthCare_Month2.length
        this.SafetyProtectionSystemCount_Month1 = this.SafetyProtectionSystem_Month1.length
        this.SafetyProtectionSystemCount_Month2 = this.SafetyProtectionSystem_Month2.length
        this.HSEIMSCount_Month1 = this.HSEIMS_Month1.length
        this.HSEIMSCount_Month2 = this.HSEIMS_Month2.length
        this.EquipmentCount_Month1 = this.Equipment_Month1.length
        this.EquipmentCount_Month2 = this.Equipment_Month2.length
        this.OtherCategoryCount_Month1 = this.OtherCategory_Month1.length
        this.OtherCategoryCount_Month2 = this.OtherCategory_Month2.length

        this.AddCanvas("myChart2","chart2")

        var myChart = new Chart("myChart2", {
          type: 'bar',
          data: {
            labels: this.categories,
            datasets: [{
              label: this.month1_Name,
              data: [
                this.BypassingSafetyControlsCount_Month1 ,
                this.DrivingCount_Month1 ,
                this.EnergyIsolationCount_Month1 ,
                this.HotWorkCount_Month1 ,
                this.LineofFireCount_Month1 ,
                this.SafeMechanicalLiftingCount_Month1 ,
                this.WorkAuthorizationCount_Month1 ,
                this.WorkingatHeightCount_Month1 ,
                this.PPECount_Month1 ,
                this.HousekeepingCount_Month1 ,
                this.EnvironmentalCount_Month1 ,
                this.HealthCareCount_Month1 ,
                this.SafetyProtectionSystemCount_Month1 ,
                this.HSEIMSCount_Month1 ,
                this.EquipmentCount_Month1 ,
                this.OtherCategoryCount_Month1 ,
              ],
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)'
                ],
                font: {
                  size: 18,
                }
              }
            }
            ,{
              label: this.month2_Name,
              data: [
                this.BypassingSafetyControlsCount_Month2 ,
                this.DrivingCount_Month2 ,
                this.EnergyIsolationCount_Month2 ,
                this.HotWorkCount_Month2 ,
                this.LineofFireCount_Month2 ,
                this.SafeMechanicalLiftingCount_Month2 ,
                this.WorkAuthorizationCount_Month2 ,
                this.WorkingatHeightCount_Month2 ,
                this.PPECount_Month2 ,
                this.HousekeepingCount_Month2 ,
                this.EnvironmentalCount_Month2 ,
                this.HealthCareCount_Month2 ,
                this.SafetyProtectionSystemCount_Month2 ,
                this.HSEIMSCount_Month2 ,
                this.EquipmentCount_Month2 ,
                this.OtherCategoryCount_Month2
              ],
              backgroundColor: [
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)'
              ],
              borderColor: [
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)'
                ],
                font: {
                  size: 18,
                }
              }
            }
          ]
          },
          options: {
            scales: {
              y: {
                beginAtZero: true
              }
            }
          }
        });

      }
    })
    ///////////////////////////////////////////////////////////////////////////////////////
    this.dataService.GetDataForChartsCompare(this.month1, this.month2,this.User.ID,this.User.Role).subscribe({
      next: data => {
        console.log(data.data)
        this.clearChart("myChart3")
        data.data.forEach((element: { date: Date; stopWorkAuthorityApplied: string; }) => {
          const validDate = new Date(element.date)

          // console.log(validDate.getMonth()+1)
          if (element.stopWorkAuthorityApplied == 'Yes' && (validDate.getMonth() + 1) == this.month1) {
            this.SWA_yes_Month1.push(element)
          }
          else if (element.stopWorkAuthorityApplied == 'Yes' && (validDate.getMonth() + 1) == this.month2) {
            this.SWA_yes_Month2.push(element)
          }
          else if (element.stopWorkAuthorityApplied == 'No' && (validDate.getMonth() + 1) == this.month1) {
            this.SWA_no_Month1.push(element)
          }
          else if (element.stopWorkAuthorityApplied == 'No' && (validDate.getMonth() + 1) == this.month2) {
            this.SWA_no_Month2.push(element)
          }
        });
        this.SWA_yesCount_Month1 = this.SWA_yes_Month1.length
        this.SWA_yesCount_Month2 = this.SWA_yes_Month2.length
        this.SWA_noCount_Month1 = this.SWA_no_Month1.length
        this.SWA_noCount_Month2 = this.SWA_no_Month2.length

        this.AddCanvas("myChart3","chart3")

        var myChart = new Chart("myChart3", {
          type: 'bar',
          data: {
            labels: ["Yes", "No"],
            datasets: [{
              label: this.month1_Name,
              data: [
                this.SWA_yesCount_Month1 ,
                this.SWA_noCount_Month1 ,
              ],
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(255, 99, 132, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 99, 132, 1)'
                ],
                font: {
                  size: 18,
                }
              }
            }
            ,{
              label: this.month2_Name,
              data: [
                this.SWA_yesCount_Month2 ,
                this.SWA_noCount_Month2 ,
              ],
              backgroundColor: [
                'rgba(54, 162, 235, 0.2)',
                'rgba(54, 162, 235, 0.2)'
              ],
              borderColor: [
                'rgba(54, 162, 235, 1)',
                'rgba(54, 162, 235, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(54, 162, 235, 1)',
                  'rgba(54, 162, 235, 1)'
                ],
                font: {
                  size: 18,
                }
              }
            }
          ]
          },
          options: {
            scales: {
              y: {
                beginAtZero: true
              }
            }
          }
        });

      }
    })
  }
}
