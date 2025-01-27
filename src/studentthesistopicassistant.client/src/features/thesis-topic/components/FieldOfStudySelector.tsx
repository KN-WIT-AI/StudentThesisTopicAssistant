import { CircularSelector } from "./CircularSelector";

const fieldsOfStudy = [
  "Informatyka Techniczna",
  "Informatyka Stosowana",
  "Architektura",
  "Automatyka i Robotyka",
  "Elektrotechnika",
  "Elektronika",
  "Telekomunikacja",
  "Inżynieria Biomedyczna",
  "Inżynieria Chemiczna",
  "Inżynieria Materiałowa",
  "Inżynieria Środowiska",
  "Chemia",
  "Fizyka Techniczna",
  "Matematyka",
  "Mechanika i Budowa Maszyn",
];

type Props = {
  onSelect?: (fieldOfStudy: string) => void;
};

export function FieldOfStudySelector(props: Props) {
  return (
    <CircularSelector
      options={fieldsOfStudy}
      onSelect={(e) => props.onSelect?.(e)}
    />
  );
}
