import { FormBase } from './../models/form-base';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-field-base',
  templateUrl: './field-base.component.html',
  styleUrls: ['./field-base.component.scss']
})
export class FieldBaseComponent implements OnInit {
  ngOnInit(): void {

  }
  @Input() question!: FormBase<string>;
  @Input() form!: FormGroup;
  get isValid() { return this.form.controls[this.question.key].valid; }

}
