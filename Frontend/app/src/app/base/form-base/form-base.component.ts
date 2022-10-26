import { CustomControl } from './models/custom-control';
import { InputTextControl } from './models/inputtext-control';
import { DatePickerControl } from './models/datepicker-control';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EditorControl } from './models/editor-control';

@Component({
  selector: 'app-form-base',
  templateUrl: './form-base.component.html',
  styleUrls: ['./form-base.component.scss']
})
export class FormBaseComponent implements OnInit {

  controls: any[] = [
    new CustomControl({
      key: 'firstName',
      label: 'First name',
      value: '',
      required: true
    })
  ];
  form!: FormGroup;
  payLoad = '';

  constructor() { }

  ngOnInit() {
    this.form = this.toFormGroup(this.controls as any[]);
  }

  onSubmit() {
    this.payLoad = JSON.stringify(this.form.getRawValue());
  }



  toFormGroup(controls: any[]) {
    const group: any = {};

    controls.forEach(field => {
      group[field.key] = field.required ? new FormControl(field.value || '', Validators.required)
        : new FormControl(field.value || '');
    });
    return new FormGroup(group);
  }
}
