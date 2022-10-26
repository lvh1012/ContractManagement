import { Validators } from '@angular/forms';
import { BaseControl } from './base-control';

export class SliderControl extends BaseControl {
  override controlType = 'Slider';
  min?: number;
  max?: number;
  step?: number;
  range?: boolean;
  orientation?: string;

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
    min?: number;
    max?: number;
    step?: number;
    range?: boolean;
    orientation?: 'horizontal' | 'vertical';
  }) {
    super(options);
    this.min = options.min;
    this.max = options.max;
    this.step = options.step || 1;
    this.orientation = options.orientation || 'horizontal';
    this.range = !!options.range || false;
  }
}
