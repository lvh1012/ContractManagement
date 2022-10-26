import { Validators } from '@angular/forms';
import { BaseControl } from './base-control';

export class CheckboxControl extends BaseControl {
  override controlType = 'Checkbox';
  dataSource?: Array<any>;
  optionLabel?: string;
  optionValue?: string;
  binary?: boolean;
  checkboxIcon?: boolean;

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
    appendTo?: string;
    showClear?: boolean;
    validators?: Validators[];
    dataSource?: Array<any>;
    optionLabel?: string;
    optionValue?: string;
    binary?: boolean;
    checkboxIcon?: boolean;
  }) {
    super(options);
    this.dataSource = options.dataSource;
    this.binary = !!options.binary || false;
    this.checkboxIcon = !!options.checkboxIcon || false;
    this.optionLabel = options.optionLabel || 'label';
    this.optionValue = options.optionValue || 'value';
  }
}
