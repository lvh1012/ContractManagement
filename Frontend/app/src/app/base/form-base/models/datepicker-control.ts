import { Validators } from '@angular/forms';
import { BaseControl } from './base-control';

export class DatePickerControl extends BaseControl {
  override controlType = 'DatePicker';
  dateFormat?: string;
  inline?: boolean;
  showTime?: boolean;
  hourFormat?: number;
  minDate?: Date;
  maxDate?: Date;
  readonlyInput?: boolean;
  disabledDates?: Array<Date>;
  disabledDays?: Array<number>;
  showButtonBar?: boolean;
  view?: 'year' | 'month' | 'date';
  selectionMode?: 'single' | 'multiple' | 'range';
  defaultDate?: Date;
  showIcon?: boolean;

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
    showClear?: boolean;
    validators?: Validators[];
    dateFormat?: string;
    inline?: boolean;
    showTime?: boolean;
    hourFormat?: number;
    minDate?: Date;
    maxDate?: Date;
    readonlyInput?: boolean;
    disabledDates?: Array<Date>;
    disabledDays?: Array<number>;
    showButtonBar?: boolean;
    view?: 'year' | 'month' | 'date';
    selectionMode?: 'single' | 'multiple' | 'range';
    defaultDate?: Date;
    appendTo?: string;
    showIcon?: boolean;
  }) {
    super(options);
    this.dateFormat = options.dateFormat;
    this.inline = !!options.inline || false;
    this.showTime = !!options.showTime || false;
    this.hourFormat = options.hourFormat || 24;
    this.minDate = options.minDate;
    this.maxDate = options.maxDate;
    this.readonlyInput = !!options.readonlyInput || false;
    this.disabledDates = options.disabledDates;
    this.disabledDays = options.disabledDays;
    this.showButtonBar = !!options.showButtonBar || false;
    this.view = options.view || 'date';
    this.selectionMode = options.selectionMode || 'single';
    this.defaultDate = options.defaultDate;
    this.showIcon = !!options.showIcon || true;
  }
}
