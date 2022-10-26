import { Validators } from '@angular/forms';
import { BaseControl } from './base-control';

export class InputSwitchControl extends BaseControl {
  override controlType = 'InputNumber';
  useGrouping?: boolean;
  minFractionDigits?: number;
  maxFractionDigits?: number;
  min?: number;
  max?: number;
  mode?: string;
  currency?: string;
  currencyDisplay?: string;
  locale?: string;
  prefix?: string;
  suffix?: string;
  step?: number;
  showButtons?: boolean;
  buttonLayout?: string;
  decrementButtonClass?: string;
  incrementButtonClass?: string;
  incrementButtonIcon?: string;
  decrementButtonIcon?: string;

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
    useGrouping?: boolean;
    minFractionDigits?: number;
    maxFractionDigits?: number;
    min?: number;
    max?: number;
    mode?: 'decimal' | 'currency';
    currency?: string;
    currencyDisplay?: string;
    locale?: string;
    prefix?: string;
    suffix?: string;
    step?: number;
    showButtons?: boolean;
    buttonLayout?: 'stacked' | 'horizontal' | 'vertical';
    decrementButtonClass?: string;
    incrementButtonClass?: string;
    incrementButtonIcon?: string;
    decrementButtonIcon?: string;
  }) {
    super(options);
    this.useGrouping = !!options.useGrouping || false;
    this.minFractionDigits = options.minFractionDigits;
    this.maxFractionDigits = options.maxFractionDigits;
    this.min = options.min;
    this.max = options.max;
    this.mode = options.mode || 'decimal';
    this.currency = options.currency;
    this.suffix = options.suffix;
    this.prefix = options.prefix;
    this.step = options.step || 1;
    this.showButtons = !!options.showButtons || false;
    this.buttonLayout = options.buttonLayout || 'stacked';
    this.decrementButtonClass = options.decrementButtonClass;
    this.incrementButtonClass = options.incrementButtonClass;
    this.incrementButtonIcon = options.incrementButtonIcon || 'pi pi-chevron-up';
    this.decrementButtonIcon = options.decrementButtonIcon || 'pi pi-chevron-down';
  }
}
