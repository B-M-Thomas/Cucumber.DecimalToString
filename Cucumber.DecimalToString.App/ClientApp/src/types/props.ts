export type UserInputFormProps = {
  onSubmit: (firstName: string, lastName: string, number: number) => void;
};

export type ResultsDialogProps = {
  firstName: string;
  lastName: string;
  numberResult: string;
  open: boolean;
  isLoading: boolean;
  handleClose: () => void;
};
