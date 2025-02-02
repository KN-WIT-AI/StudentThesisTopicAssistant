import { PhraseQuality } from "../models/phrase-quality";
import { Topic } from "../models/topic";

export async function fetchThemes(
  fieldOfStudy: string,
  degree: string,
  alreadySelectedThemes: string[]
): Promise<PhraseQuality[]> {
  const response = await fetch("/api/themes/generate", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ fieldOfStudy, degree, alreadySelectedThemes }),
  });
  const responseJson = await response.json();
  return responseJson.themes;
}

export async function fetchTopics(
  fieldOfStudy: string,
  degree: string,
  selectedThemes: string[]
): Promise<Topic[]> {
  const response = await fetch("/api/topics/generate", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ fieldOfStudy, degree, selectedThemes }),
  });
  const responseJson = await response.json();
  return responseJson.topics;
}