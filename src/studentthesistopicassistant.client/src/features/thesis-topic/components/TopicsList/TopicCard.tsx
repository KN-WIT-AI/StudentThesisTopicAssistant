import { Card, CardContent, Typography } from "@mui/material";
import { Topic } from "../../models/topic";

type Props = {
  topic: Topic;
};

export function TopicCard(props: Props) {
  return (
    <Card className="w-full h-full !overflow-auto">
      <CardContent>
        <Typography variant="h5" component="div">
          {props.topic.title}
        </Typography>
        <Typography variant="body2" color="text.secondary" align="justify">
          {props.topic.description}
        </Typography>

        <Typography variant="h6" component="div">
          Propozycje rozdziałów:
        </Typography>
        {props.topic.sections.map((section) => (
          <Typography key={section} variant="body2" color="text.secondary" align="justify">
            {section}
          </Typography>
        ))}
      </CardContent>
    </Card>
  );
}
