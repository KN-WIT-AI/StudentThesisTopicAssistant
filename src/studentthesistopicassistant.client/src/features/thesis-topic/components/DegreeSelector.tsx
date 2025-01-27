import { CircularSelector } from "./CircularSelector";

const degrees = [
  "Inżynier",
  "Magister"
];

type Props = {
  onSelect?: (fieldOfStudy: string) => void;
};

export function DegreeSelector(props: Props) {
  return (
    <CircularSelector
      options={degrees}
      onSelect={(e) => props.onSelect?.(e)}
    />
  );
}
