import { AddRigMovePerformanceEvaluationService } from './../../../Services/add-rig-move-performance-evaluation.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { DataService } from 'Services/data.service';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { IRigMovePerformanceEvaluation } from 'SharedClasses/IRigMovePerformanceEvaluation';

@Component({
  selector: 'app-edit-rig-move-performance-evaluation',
  templateUrl: './edit-rig-move-performance-evaluation.component.html',
  styleUrls: ['./edit-rig-move-performance-evaluation.component.scss']
})
export class EditRigMovePerformanceEvaluationComponent {
  RigPerformanceId: any;
  RigPerformance!: IRigMovePerformanceEvaluation;
  RigPerformanceForm!: FormGroup;
  ErrorMessage = '';
  json_data: any[] = [];
  UserJsonString: any;
  UserJsonObj: any;

  DateDiff: number = 0

  rigList: IRig[] = [];
  User:any;


  constructor(private activatedRoute: ActivatedRoute,
    private fb: FormBuilder, private router: Router,
    private rigMovePerformance: AddRigMovePerformanceEvaluationService
    , private dataService: DataService,
    private loginService: LoginService,
    private editService: EditDataService) {

  }


  ngOnInit(): void {
    this.User=this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.RigPerformanceId = params.get("id");
      console.log(this.RigPerformanceId)
    }),
      this.rigMovePerformance.GetRigMovePerformanceEvaluationById(this.RigPerformanceId,this.User.ID,this.User.Role).subscribe({
        next: data => {
          this.RigPerformance = data.data,
            console.log('*************************************************************')
          console.log(this.RigPerformance)
          console.log('###################################################')
        },
        error: (erorr: string) => this.ErrorMessage = erorr
      }),

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
        budgetTargetTotalDay: this.fb.control('', [Validators.required,Validators.pattern('^[0-9]*(\.[0-9][0-9]?)?$')]),
        budgetTargetTotalMoney: this.fb.control('', [Validators.required]),
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
        timeLostProblem1: this.fb.control(0, [Validators.pattern('^[0-9]*(\.[0-5][0-9]?|\.59?)?$')]),

        item2: this.fb.control('Item2', []),
        problemDescription2: this.fb.control('', []),
        recommendationProblemRepeated2: this.fb.control('', []),
        timeLostProblem2: this.fb.control(0, [Validators.pattern('^[0-9]*(\.[0-5][0-9]?|\.59?)?$')]),

        item3: this.fb.control('Item3', []),
        problemDescription3: this.fb.control('', []),
        recommendationProblemRepeated3: this.fb.control('', []),
        timeLostProblem3: this.fb.control(0, [Validators.pattern('^[0-9]*(\.[0-5][0-9]?|\.59?)?$')]),

        item4: this.fb.control('Item4', []),
        problemDescription4: this.fb.control('', []),
        recommendationProblemRepeated4: this.fb.control('', []),
        timeLostProblem4: this.fb.control(0, [Validators.pattern('^[0-9]*(\.[0-5][0-9]?|\.59?)?$')]),

        item5: this.fb.control('Item5', []),
        problemDescription5: this.fb.control('', []),
        recommendationProblemRepeated5: this.fb.control('', []),
        timeLostProblem5: this.fb.control(0, [Validators.pattern('^[0-9]*(\.[0-5][0-9]?|\.59?)?$')]),
      })
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

  submitData() {

    this.editService.EditRigMovePerformance(this.RigPerformanceId, this.RigPerformanceForm.value)
      .subscribe({
        next: (data) => {
          console.log('from service');
          console.log(data);
          this.router.navigate(['/RigPerformance']);
        },
        error: (error) => {
          console.log('from Error');
          console.log(error);
        },
      });


  }

}
