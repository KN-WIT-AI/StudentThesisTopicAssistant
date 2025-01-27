import { Button } from "@mui/material";

type Props = {
  options: string[];
  onSelect?: (option: string) => void;
};

export function CircularSelector(props: Props) {
  return (
    <div className="flex flex-col">
      {props.options.map((option) => (
        <Button
          key={option}
          onClick={() => props.onSelect?.(option)}
        >
          {option}
        </Button>
      ))}
    </div>
  );
}
