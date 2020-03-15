import React from "react";
import NumberFormat from "react-number-format";

const CurrencyInput: React.FC<any> = ({ inputRef, onChange, ...other }) => {
  return (
    <NumberFormat
      {...other}
      maxLength={16}
      decimalScale={2}
      getInputRef={inputRef}
      onValueChange={values => {
        onChange({
          target: {
            value: values.value
          }
        });
      }}
      thousandSeparator
      isNumericString
      prefix="$"
    />
  );
};

export default CurrencyInput;
