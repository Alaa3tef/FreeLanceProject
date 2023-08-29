import { AddRigMovePerformanceEvaluationService } from './../../../Services/add-rig-move-performance-evaluation.service';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ValidatorFn, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';
import { IRig } from 'SharedClasses/IRig';

@Component({
  selector: 'app-add-rig-move-performance-evaluation',
  templateUrl: './add-rig-move-performance-evaluation.component.html',
  styleUrls: ['./add-rig-move-performance-evaluation.component.scss'],
})
export class AddRigMovePerformanceEvaluationComponent {
  RigPerformanceForm!: FormGroup;
  ErrorMessage = '';
  UserJsonString: any;
  UserJsonObj: any;
  json_data: any[] = [];
  problemFacedDuringRigMoves: any[] = [];
  rigList: IRig[] = [];
  selectedRelase!: Date;
  selectedAcceptance!: Date;
  ValidDate: boolean = true;
  DateDiff: number = 0;
  User:any;


  constructor(
    private loginService: LoginService,
    private addRigPerformance: AddRigMovePerformanceEvaluationService,
    private fb: FormBuilder,
    private router: Router,
    private dataService: DataService

  ) { }

  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.UserJsonString = JSON.stringify(
      this.loginService.currentUser.getValue()
    );
    this.UserJsonObj = JSON.parse(this.UserJsonString);



    this.dataService.GetRig().subscribe({
      next: (data) => {
        this.rigList = data.data
        console.log("rigList")
        console.log(this.rigList)
      },
      error: (err) => (this.ErrorMessage = err),
    }),


      this.RigPerformanceForm = this.fb.group({
        id: this.fb.control(0, [Validators.required]),
        rigId: this.fb.control(0, [Validators.required]),
        budgetTargetTotalDay: this.fb.control('', [Validators.required,Validators.pattern('^[0-9]*(\.[0-9][0-9]?)?$')]),        budgetTargetTotalMoney: this.fb.control('', [Validators.required]),
        targetArchived: this.fb.control('', [Validators.required]),
        actualMoveTime: this.fb.control('', [Validators.required]),
        acceptanceTime: this.fb.control('', [Validators.required]),
        releaseTime: this.fb.control('', [Validators.required]),
        dieselConsumed: this.fb.control('', [Validators.required]),
        releaseDate: this.fb.control('', [Validators.required]),
        acceptanceDate: this.fb.control('', [Validators.required]),
        moveDistance: this.fb.control('', [Validators.required]),
        oldWellName: this.fb.control('', [Validators.required]),
        newWellName: this.fb.control('', [Validators.required]),
        userId: this.fb.control(this.UserJsonObj.ID, [Validators.required]),

        item1: this.fb.control('Item1', []),
        problemDescription1: this.fb.control('', []),
        recommendationProblemRepeated1: this.fb.control('', []),
        timeLostProblem1: this.fb.control('', [
          Validators.pattern('^[0-9]*(\.[0-5][0-9]?|\.59?)?$')
        ]),

        item2: this.fb.control('Item2', []),
        problemDescription2: this.fb.control('', []),
        recommendationProblemRepeated2: this.fb.control('', []),
        timeLostProblem2: this.fb.control('', [
          Validators.pattern('^[0-9]*(\.[0-5][0-9]?|\.59?)?$')
        ]),

        item3: this.fb.control('Item3', []),
        problemDescription3: this.fb.control('', []),
        recommendationProblemRepeated3: this.fb.control('', []),
        timeLostProblem3: this.fb.control('', [
          Validators.pattern('^[0-9]*(\.[0-5][0-9]?|\.59?)?$')
        ]),

        item4: this.fb.control('Item4', []),
        problemDescription4: this.fb.control('', []),
        recommendationProblemRepeated4: this.fb.control('', []),
        timeLostProblem4: this.fb.control('', [
          Validators.pattern('^[0-9]*(\.[0-5][0-9]?|\.59?)?$')
        ]),

        item5: this.fb.control('Item5', []),
        problemDescription5: this.fb.control('', []),
        recommendationProblemRepeated5: this.fb.control('', []),
        timeLostProblem5: this.fb.control('', [
          Validators.pattern('^[0-9]*(\.[0-5][0-9]?|\.59?)?$')
        ]),
      })
    this.addRigPerformance.GetRigMovePerformanceEvaluationWithDataExcel( this.User.ID, this.User.Role).subscribe({
      next: (data) => {
        this.json_data = data.data
      },
      error: (err) => this.ErrorMessage = err
    });

  }

  onInput(event: any) {

    const Acceptyear = Number(this.acceptanceDate?.value.slice(0, 4));
    const Acceptmonth = Number(this.acceptanceDate?.value.slice(5, 7)) - 1; // Months are zero-indexed
    const Acceptday = Number(this.acceptanceDate?.value.slice(8, 10));
    const Accepthour = Number(this.acceptanceTime?.value.slice(0, 2));
    const Acceptminute = Number(this.acceptanceTime?.value.slice(3, 5));
    const Acceptsecond = Number(this.acceptanceTime?.value.slice(6, 8));
    const Releaseyear = Number(this.releaseDate?.value.slice(0, 4));
    const Releasemonth = Number(this.releaseDate?.value.slice(5, 7)) - 1; // Months are zero-indexed
    const Releaseday = Number(this.releaseDate?.value.slice(8, 10));
    const Releasehour = Number(this.releaseTime?.value.slice(0, 2));
    const Releaseminute = Number(this.releaseTime?.value.slice(3, 5));
    const Releasesecond = Number(this.releaseTime?.value.slice(6, 8));

    const validDate1 = new Date(Acceptyear, Acceptmonth, Acceptday, Accepthour, Acceptminute, Acceptsecond)
    const validDate2 = new Date(Releaseyear, Releasemonth, Releaseday, Releasehour, Releaseminute, Releasesecond)

    this.DateDiff = parseFloat(((Math.abs(validDate1.getTime() - validDate2.getTime())) / (1000 * 3600 * 24)).toFixed(1));
  }

  get id() {
    return this.RigPerformanceForm.get('id');
  }
  get newWellName() {
    return this.RigPerformanceForm.get('newWellName');
  }

  get oldWellName() {
    return this.RigPerformanceForm.get('oldWellName');
  }
  get moveDistance() {
    return this.RigPerformanceForm.get('moveDistance');
  }

  get acceptanceDate() {
    return this.RigPerformanceForm.get('acceptanceDate');
  }
  get releaseDate() {
    return this.RigPerformanceForm.get('releaseDate');
  }

  get dieselConsumed() {
    return this.RigPerformanceForm.get('dieselConsumed');
  }
  get releaseTime() {
    return this.RigPerformanceForm.get('releaseTime');
  }

  get acceptanceTime() {
    return this.RigPerformanceForm.get('acceptanceTime');
  }
  get actualMoveTime() {
    return this.RigPerformanceForm.get('actualMoveTime');
  }

  get targetArchived() {
    return this.RigPerformanceForm.get('targetArchived');
  }
  get budgetTargetTotalDay() {
    return this.RigPerformanceForm.get('budgetTargetTotalDay');
  }

  get budgetTargetTotalMoney() {
    return this.RigPerformanceForm.get('budgetTargetTotalMoney');
  }


  get rigId() {
    return this.RigPerformanceForm.get('rigId');
  }

  get item1() {
    return this.RigPerformanceForm.get('item1');
  }

  get problemDescription1() {
    return this.RigPerformanceForm.get('problemDescription1');
  }

  get recommendationProblemRepeated1() {
    return this.RigPerformanceForm.get('recommendationProblemRepeated1');
  }
  get timeLostProblem1() {
    return this.RigPerformanceForm.get('timeLostProblem1');
  }

  get item2() {
    return this.RigPerformanceForm.get('item2');
  }

  get problemDescription2() {
    return this.RigPerformanceForm.get('problemDescription2');
  }

  get recommendationProblemRepeated2() {
    return this.RigPerformanceForm.get('recommendationProblemRepeated2');
  }
  get timeLostProblem2() {
    return this.RigPerformanceForm.get('timeLostProblem2');
  }

  get item3() {
    return this.RigPerformanceForm.get('item3');
  }

  get problemDescription3() {
    return this.RigPerformanceForm.get('problemDescription3');
  }

  get recommendationProblemRepeated3() {
    return this.RigPerformanceForm.get('recommendationProblemRepeated3');
  }
  get timeLostProblem3() {
    return this.RigPerformanceForm.get('timeLostProblem3');
  }

  get item4() {
    return this.RigPerformanceForm.get('item4');
  }

  get problemDescription4() {
    return this.RigPerformanceForm.get('problemDescription4');
  }

  get recommendationProblemRepeated4() {
    return this.RigPerformanceForm.get('recommendationProblemRepeated4');
  }
  get timeLostProblem4() {
    return this.RigPerformanceForm.get('timeLostProblem4');
  }

  get item5() {
    return this.RigPerformanceForm.get('item5');
  }

  get problemDescription5() {
    return this.RigPerformanceForm.get('problemDescription5');
  }

  get recommendationProblemRepeated5() {
    return this.RigPerformanceForm.get('recommendationProblemRepeated5');
  }
  get timeLostProblem5() {
    return this.RigPerformanceForm.get('timeLostProblem5');
  }

  ChangeRelase(event: any) {
    console.log(event.target.value)
    this.selectedRelase = new Date(event.target.value)
  }

  ChangeAcceptance(event: any) {
    console.log(event.target.value)
    this.selectedAcceptance = new Date(event.target.value)
    if ((this.selectedAcceptance.getDate()) >= (this.selectedRelase.getDate())) {
      this.ValidDate = true;
    } else {
      this.ValidDate = false;
    }
    console.log(this.ValidDate)
  }



  submitData() {
    this.addRigPerformance
      .AddRigMovePerformanceEvaluation(this.RigPerformanceForm.value)
      .subscribe({
        next: (data) => {
          console.log('from service');
          console.log(data);
          location.reload();
        },
        error: (error) => {
          console.log('from Error');
          console.log(error);
        },
      });
  }

  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet('RMPE Data');

    let header = Object.keys(this.json_data[0]);

    let headerRow = worksheet.addRow(header);

    headerRow.fill = {
      type: 'pattern',
      pattern: 'solid',
      fgColor: {
        argb: 'ff0e0a27',
      },
    };

    headerRow.font = {
      name: 'Calibri',
      size: 12,
      bold: true,
      color: {
        argb: 'ffffffff',
      },
    };

    headerRow.alignment = {
      horizontal: 'center',
      vertical: 'middle',
      wrapText: true,
    };

    headerRow.eachCell((cell, colNumber) => {
      worksheet.getColumn(colNumber).width = Math.max(
        header[colNumber - 1].length + 10,
        15
      );
      worksheet.getRow(1).height = 35;
    });

    for (let x1 of this.json_data) {
      let x2 = Object.keys(x1);
      let temp: any[] = [];
      for (let y of x2) {
        temp.push(x1[y]);
      }
      worksheet.addRow(temp);
    }

    let fname = 'RMPE Report';

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], {
        type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
      });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }
}
