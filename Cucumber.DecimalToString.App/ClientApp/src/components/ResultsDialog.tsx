import React from "react";
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogContentText,
  DialogActions,
  Button,
  Typography
} from "@material-ui/core";
import { ResultsDialogProps } from "../types/props";

const ResultsDialog: React.FC<ResultsDialogProps> = ({
  firstName,
  lastName,
  numberResult,
  handleClose,
  open
}) => {
  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>{firstName + " " + lastName}</DialogTitle>
      <DialogContent>
        <Typography variant="h5">{numberResult}</Typography>
      </DialogContent>
      <DialogActions>
        <Button onClick={handleClose} color="primary">
          Close
        </Button>
      </DialogActions>
    </Dialog>
  );
};
export default ResultsDialog;
