import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { IRig } from 'SharedClasses/IRig';
import { Chart, registerables } from 'chart.js';
import ChartDataLabels from 'chartjs-plugin-datalabels';
import { LoginService } from 'Services/login.service';
Chart.register(ChartDataLabels);
Chart.register(...registerables);

@Component({
  selector: 'app-rig-performance-compare-charts',
  templateUrl: './rig-performance-compare-charts.component.html',
  styleUrls: ['./rig-performance-compare-charts.component.scss']
})
export class RigPerformanceCompareChartsComponent {
  clearChart(ID_Name: string) {
    const myElement = document.querySelector('#' + ID_Name) as HTMLElement;
    myElement.remove()
    this.RigPerformanceList1 = [];
    this.RigPerformanceList2 = [];
    this.DateDiff = [];
    this.Months = [];
    this.DateDiff2 = [];
    this.Months2 = [];
    this.YesList_Rig1 = [];
    this.NoList_Rig1 = [];
    this.YesList_Rig2 = [];
    this.NoList_Rig2 = [];
  }

  AddCanvas(ID_Name: string, DIV_Name: string) {
    // Create a new element
    var newElement = document.createElement('canvas');
    newElement.id = ID_Name

    // Get the parent element where you want to append the new element
    const myElement = document.querySelector('#' + DIV_Name) as HTMLElement;

    // Append the new element to the parent element
    myElement.appendChild(newElement);
  }

  temp: boolean = false;
  RigList: IRig[] = [];
  YearList: number[] = [];
  Year: number = 0;
  ErrorMessage: string = '';
  RigPerformanceList1: any[] = [];
  RigPerformanceList2: any[] = [];
  DateDiff: any[] = [];
  Months: any[] = [];
  DateDiff2: any[] = [];
  Months2: any[] = [];
  YesList_Rig1: any[] = [];
  Yes_Count_Rig1: number = 0;
  YesList_Rig2: any[] = [];
  Yes_Count_Rig2: number = 0;
  NoList_Rig1: any[] = [];
  No_Count_Rig1: number = 0;
  NoList_Rig2: any[] = [];
  No_Count_Rig2: number = 0;

  Rig1: number = 0;
  Rig2: number = 0;
  Rig1_Name: string = '';
  Rig2_Name: string = '';
  User:any;

  constructor(private dataService: DataService,private loginService:LoginService) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.User=this.loginService.currentUser.getValue();
    this.dataService.GetRig().subscribe({
      next: data => {
        this.RigList = data.data
      },
      error: err => {
        this.ErrorMessage = err
      }
    })
    this.dataService.GetRigPerformanceData(this.User.ID,this.User.Role).subscribe({
      next: data => {
        data.data.forEach((element: any) => {
          const Acceptyear = Number(element.acceptanceDate.slice(0, 4));
          this.YearList.push(Acceptyear)
          const Releaseyear = Number(element.releaseDate.slice(0, 4));
          this.YearList.push(Releaseyear)
        });
        this.YearList = Array.from(new Set(this.YearList))
      },
      error: err => {
        this.ErrorMessage = err
      }
    })
  }

  onRig1Change(event: any) {
    this.Rig1 = event.target.value
    const myComboBox = document.getElementById('Rig1') as HTMLSelectElement;
    const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    const selectedText = selectedOption.text;
    this.Rig1_Name = selectedText
  }

  onRig2Change(event: any) {
    this.Rig2 = event.target.value
    const myComboBox = document.getElementById('Rig2') as HTMLSelectElement;
    const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    const selectedText = selectedOption.text;
    this.Rig2_Name = selectedText
  }

  onYearChange(event: any) {
    this.Year = event.target.value
  }

  onChange(event: any) {
    console.log(event.target.value)
    const myComboBox = document.getElementById('Rig1') as HTMLSelectElement;
    const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    const selectedText = selectedOption.text;
    const myComboBox2 = document.getElementById('Rig2') as HTMLSelectElement;
    const selectedOption2 = myComboBox.options[myComboBox2.selectedIndex];
    const selectedText2 = selectedOption2.text;
    this.temp = true;
    this.dataService.GetRigPerformanceDataForCompareCharts(this.Rig1, this.Rig2, this.Year,this.User.ID,this.User.Role).subscribe({
      next: data => {
        this.clearChart("myChart")
        data.data.forEach((element: { rigId: number; }) => {
          if (element.rigId == this.Rig1) {
            this.RigPerformanceList1.push(element)
          }
          else if (element.rigId == this.Rig2) {
            this.RigPerformanceList2.push(element)
          }
        });
        this.RigPerformanceList1.forEach((Element) => {
          const Acceptyear = Number(Element.acceptanceDate.slice(0, 4));
          const Acceptmonth = Number(Element.acceptanceDate.slice(5, 7)) - 1; // Months are zero-indexed
          const Acceptday = Number(Element.acceptanceDate.slice(8, 10));
          const Accepthour = Number(Element.acceptanceTime.slice(0, 2));
          const Acceptminute = Number(Element.acceptanceTime.slice(3, 5));
          const Acceptsecond = Number(Element.acceptanceTime.slice(6, 8));
          const Releaseyear = Number(Element.releaseDate.slice(0, 4));
          const Releasemonth = Number(Element.releaseDate.slice(5, 7)) - 1; // Months are zero-indexed
          const Releaseday = Number(Element.releaseDate.slice(8, 10));
          const Releasehour = Number(Element.releaseTime.slice(0, 2));
          const Releaseminute = Number(Element.releaseTime.slice(3, 5));
          const Releasesecond = Number(Element.releaseTime.slice(6, 8));

          const validDate1 = new Date(Acceptyear, Acceptmonth, Acceptday, Accepthour, Acceptminute, Acceptsecond)
          const validDate2 = new Date(Releaseyear, Releasemonth, Releaseday, Releasehour, Releaseminute, Releasesecond)

          console.log(validDate1)
          console.log(validDate2)

          this.DateDiff.push(((Math.abs(validDate1.getTime() - validDate2.getTime())) / (1000 * 3600 * 24)).toFixed(2));
          console.log(this.DateDiff)

          this.Months.push((validDate2.toLocaleString('en-US', { month: 'short', }).toString()) + ' - ' + (validDate1.toLocaleString('en-US', { month: 'short', }).toString()))
        })

        this.RigPerformanceList2.forEach((Element) => {
          const Acceptyear = Number(Element.acceptanceDate.slice(0, 4));
          const Acceptmonth = Number(Element.acceptanceDate.slice(5, 7)) - 1; // Months are zero-indexed
          const Acceptday = Number(Element.acceptanceDate.slice(8, 10));
          const Accepthour = Number(Element.acceptanceTime.slice(0, 2));
          const Acceptminute = Number(Element.acceptanceTime.slice(3, 5));
          const Acceptsecond = Number(Element.acceptanceTime.slice(6, 8));
          const Releaseyear = Number(Element.releaseDate.slice(0, 4));
          const Releasemonth = Number(Element.releaseDate.slice(5, 7)) - 1; // Months are zero-indexed
          const Releaseday = Number(Element.releaseDate.slice(8, 10));
          const Releasehour = Number(Element.releaseTime.slice(0, 2));
          const Releaseminute = Number(Element.releaseTime.slice(3, 5));
          const Releasesecond = Number(Element.releaseTime.slice(6, 8));

          const validDate1 = new Date(Acceptyear, Acceptmonth, Acceptday, Accepthour, Acceptminute, Acceptsecond)
          const validDate2 = new Date(Releaseyear, Releasemonth, Releaseday, Releasehour, Releaseminute, Releasesecond)

          console.log(validDate1)
          console.log(validDate2)

          this.DateDiff2.push(((Math.abs(validDate1.getTime() - validDate2.getTime())) / (1000 * 3600 * 24)).toFixed(2));
          console.log(this.DateDiff2)

          this.Months2.push((validDate2.toLocaleString('en-US', { month: 'short', }).toString()) + ' - ' + (validDate1.toLocaleString('en-US', { month: 'short', }).toString()))
        })

        this.AddCanvas("myChart", "chart1")

        const ChartLabels = Array(Math.max(this.DateDiff.length, this.DateDiff2.length)).fill(this.Year)

        var myChart = new Chart("myChart", {
          type: 'bar',
          data: {
            datasets: [{
              label: this.Rig1_Name,
              // data: this.Months.map((x, i) => ({ x, y: this.DateDiff[i] })),
              data: this.DateDiff.map((value, index) => ({ x: this.Months[index], y: value })),
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)'
              ],
              borderWidth: 1,
              // radius:10,
              // datalabels: {
              //   color: [
              //     'rgba(255, 99, 132, 1)'
              //   ],
              //   font: {
              //     size: 18,
              //   }
              // }
            },
            {
              label: this.Rig2_Name,
              // data: this.Months2.map((x, i) => ({ x, y: this.DateDiff2[i] })),
              data: this.DateDiff2.map((value, index) => ({ x: this.Months2[index], y: value })),
              backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
              ],
              borderColor: [
                'rgba(54, 162, 235, 1)'
              ],
              borderWidth: 1,
              // radius:15,
              // pointStyle:'star',
              // datalabels: {
              //   color: [
              //     'rgba(54, 162, 235, 1)'
              //   ],
              //   font: {
              //     size: 18,
              //   }
              // }
            }
            ]
            //   datasets: [{
            //     label: this.Rig1_Name,
            //     data: this.DateDiff,
            //     backgroundColor: [
            //       'rgba(255, 99, 132, 0.2)'
            //     ],
            //     borderColor: [
            //       'rgba(255, 99, 132, 1)'
            //     ],
            //     borderWidth: 1,
            //     datalabels: {
            //       color: [
            //         'rgba(255, 99, 132, 1)'
            //       ],
            //       font: {
            //         size: 18,
            //       }
            //     }
            //   }
            //   // ,
            //   // {
            //   //   label: this.Rig2_Name,
            //   //   data: this.DateDiff2,
            //   //   backgroundColor: [
            //   //     'rgba(54, 162, 235, 0.2)'
            //   //   ],
            //   //   borderColor: [
            //   //     'rgba(54, 162, 235, 1)'
            //   //   ],
            //   //   borderWidth: 1,
            //   //   datalabels: {
            //   //     color: [
            //   //       'rgba(54, 162, 235, 1)'
            //   //     ],
            //   //     font: {
            //   //       size: 18,
            //   //     }
            //   //   }
            //   // }
            // ]
          },
          options: {
            responsive: true,
            plugins: {
              legend: {
                position: 'top',
              }
            },
            scales: {
              x: {
                type: 'category',
                position: 'bottom',
                offset: true

              },
              y: {
                type: 'linear',
                position: 'left',
              }
            }
          }
        });
      },
      error: err => {
        this.ErrorMessage = err
      }
    })


    this.dataService.GetRigPerformanceDataForCompareCharts(this.Rig1, this.Rig2, this.Year,this.User.ID,this.User.Role).subscribe({
      next: data => {
        this.clearChart("myChart2")
        data.data.forEach((element: { rigId: number; targetArchived: string; }) => {
          console.log('element')
          console.log(element)
          if (element.rigId==this.Rig1&&element.targetArchived == 'Yes') {
            this.YesList_Rig1.push(element)
          }
          else if (element.rigId==this.Rig2&&element.targetArchived == 'Yes') {
            this.YesList_Rig2.push(element)
          }
          else if (element.rigId==this.Rig1&&element.targetArchived == 'No') {
            this.NoList_Rig1.push(element)
          }
          else if (element.rigId==this.Rig2&&element.targetArchived == 'No') {
            this.NoList_Rig2.push(element)
          }
        });

        this.Yes_Count_Rig1 = this.YesList_Rig1.length
        this.Yes_Count_Rig2 = this.YesList_Rig2.length
        this.No_Count_Rig1 = this.NoList_Rig1.length
        this.No_Count_Rig2 = this.NoList_Rig2.length

        this.AddCanvas("myChart2", "chart2")

        var myChart2 = new Chart("myChart2", {
          type: 'bar',
          data: {
            labels: ["Yes", "No"],
            datasets: [{
              label: selectedText,
              data: [this.Yes_Count_Rig1, this.No_Count_Rig1],
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(255, 99, 132, 1)',
                ],
                font: {
                  size: 18,
                }
              }
            },
            {
              label: selectedText2,
              data: [this.Yes_Count_Rig2, this.No_Count_Rig2],
              backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
              ],
              borderColor: [
                'rgba(54, 162, 235, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(54, 162, 235, 1)'
                ],
                font: {
                  size: 18,
                }
              }
            }]
          },
          options: {
            scales: {
              y: {
                beginAtZero: true
              }
            }
          }
        });
      },
      error: err => {
        this.ErrorMessage = err
      }
    })
  }
}
