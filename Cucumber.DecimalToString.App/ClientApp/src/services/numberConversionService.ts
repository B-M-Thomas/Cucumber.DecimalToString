import * as fetch from "./fetchMethods";

export const ConvertNumberToStringRepresentation = async (
  firstName: string,
  lastName: string,
  number: string
) => {
  return await fetch.postData("https://localhost:44396/numberconversion", {
    firstName,
    lastName,
    number
  });
};
