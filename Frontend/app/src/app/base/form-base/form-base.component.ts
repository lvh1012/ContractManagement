import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FormBase } from './models/form-base';

@Component({
  selector: 'app-form-base',
  templateUrl: './form-base.component.html',
  styleUrls: ['./form-base.component.scss']
})
export class FormBaseComponent implements OnInit {

  questions: FormBase<string>[] | null = [];
  form!: FormGroup;
  payLoad = '';

  constructor() { }

  ngOnInit() {
    this.form = this.toFormGroup(this.questions as FormBase<string>[]);
  }

  onSubmit() {
    this.payLoad = JSON.stringify(this.form.getRawValue());
  }

  // get isValid() { return this.form.controls[this.question.key].valid; }


  toFormGroup(questions: FormBase<string>[]) {
    const group: any = {};

    questions.forEach(question => {
      group[question.key] = question.required ? new FormControl(question.value || '', Validators.required)
        : new FormControl(question.value || '');
    });
    return new FormGroup(group);
  }


}
