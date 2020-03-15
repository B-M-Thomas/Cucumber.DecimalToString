import React, { useState, useEffect } from "react";
import { Grid, TextField, Button } from "@material-ui/core";
import { UserInputFormProps } from "../types/props";
import CurrencyInput from "./CurrencyInput";

const UserInputForm: React.FC<UserInputFormProps> = ({ onSubmit }) => {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [number, setNumber] = useState("");
  const [showFormErrors, setShowFormErrors] = useState(false);

  const [isFormValid, setIsFormValid] = useState(false);

  const [formState, setFormState] = useState({
    firstName: true,
    lastName: true,
    number: true
  });

  useEffect(() => {
    if (firstName.trim() && lastName.trim() && number.trim()) {
      setIsFormValid(true);
    } else {
      setIsFormValid(false);
    }
  }, [firstName, lastName, number]);

  const validateForm = () => {
    setFormState({
      firstName: !!firstName.trim(),
      lastName: !!lastName.trim(),
      number: !!number.trim()
    });
    setShowFormErrors(true);
    if (isFormValid) onSubmit(firstName, lastName, parseFloat(number));
  };

  return (
    <Grid container direction="column" spacing={2} justify="center">
      <Grid item>
        <TextField
          onFocus={() => setFormState({ ...formState, firstName: true })}
          error={!formState.firstName && showFormErrors}
          label="First Name"
          value={firstName}
          onChange={event => setFirstName(event.target.value)}
          helperText={!formState.firstName && "Your First Name is required."}
        />
      </Grid>
      <Grid item>
        <TextField
          onFocus={() => setFormState({ ...formState, lastName: true })}
          error={!formState.lastName && showFormErrors}
          label="Last Name"
          value={lastName}
          onChange={event => setLastName(event.target.value)}
          helperText={!formState.lastName && "Your Last Name is required."}
        />
      </Grid>
      <Grid item>
        <TextField
          onFocus={() => setFormState({ ...formState, number: true })}
          error={!formState.number && showFormErrors}
          label="Number to Convert"
          value={number}
          onChange={event => setNumber(event.target.value)}
          helperText={!formState.number && "A Number to Convert is required."}
          InputProps={{
            inputComponent: CurrencyInput
          }}
        />
      </Grid>
      <Grid item>
        <Button
          color="primary"
          variant="outlined"
          fullWidth
          onClick={() => validateForm()}
        >
          Submit
        </Button>
      </Grid>
    </Grid>
  );
};

export default UserInputForm;
