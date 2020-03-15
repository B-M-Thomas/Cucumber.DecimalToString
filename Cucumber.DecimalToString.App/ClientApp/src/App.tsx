import React, { useState } from "react";
import { Grid } from "@material-ui/core";
import UserInputForm from "./components/UserInputForm";
import ResultsDialog from "./components/ResultsDialog";
import { ConvertNumberToStringRepresentation } from "./services/numberConversionService";
import { NumberToStringResponse } from "./types/api";

function App() {
  const [resultDialogOpen, setResultDialogOpen] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [result, setResult] = useState<NumberToStringResponse>({
    firstName: "",
    lastName: "",
    number: ""
  });

  const onSubmit = async (
    firstName: string,
    lastName: string,
    number: number
  ) => {
    setIsLoading(true);
    setResultDialogOpen(true);
    const result: NumberToStringResponse = await ConvertNumberToStringRepresentation(
      firstName,
      lastName,
      number.toFixed(2)
    );
    setIsLoading(false);
    setResult({ ...result });
  };

  return (
    <>
      <Grid
        container
        alignItems="center"
        justify="center"
        style={{ height: "100vh" }}
      >
        <Grid item>
          <UserInputForm onSubmit={onSubmit} />
        </Grid>
      </Grid>
      <ResultsDialog
        open={resultDialogOpen}
        firstName={result.firstName}
        lastName={result.lastName}
        numberResult={result.number}
        isLoading={isLoading}
        handleClose={() => setResultDialogOpen(false)}
      />
    </>
  );
}

export default App;
