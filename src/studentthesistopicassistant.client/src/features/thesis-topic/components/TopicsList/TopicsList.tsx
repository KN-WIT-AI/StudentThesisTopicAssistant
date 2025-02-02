import { Topic } from "../../models/topic";
import { TopicCard } from "./TopicCard";
import Carousel from "react-material-ui-carousel";

type Props = {
  topics: Topic[];
};

export function TopicsList(props: Props) {
  return (
    <Carousel
      className="w-dvw p-2 flex flex-col"
      animation="slide"
      height={"52dvh"}
      duration={700}
      autoPlay={false}
      navButtonsAlwaysInvisible={true}
    >
      {props.topics.map((topic) => (
        <div className="p-2 h-full" key={topic.title}>
          <TopicCard topic={topic} />
        </div>
      ))}
    </Carousel>
  );
}
