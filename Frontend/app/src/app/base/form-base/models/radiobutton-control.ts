import { Validators } from '@angular/forms';
import { BaseControl } from './base-control';

export class RadioButtonControl extends BaseControl {
  override controlType = 'RadioButton';
  dataSource?: Array<any>;
  optionLabel?: string;
  optionValue?: string;

  constructor(options: {
    key: string;
    label: string;
    type?: string;
    value?: string | number;
    required?: boolean;
    controlType?: string;
    width?: number;
    placeholder?: string;
    disabled?: boolean;
    readonly?: boolean;
    appendTo?: string;
    showClear?: boolean;
    validators?: Validators[];
    dataSource?: Array<any>;
    optionLabel?: string;
    optionValue?: string;
  }) {
    super(options);
    this.dataSource = options.dataSource;
    this.optionLabel = options.optionLabel || 'label';
    this.optionValue = options.optionValue || 'value';
  }
}
