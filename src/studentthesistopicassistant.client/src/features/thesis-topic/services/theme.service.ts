import { PhraseQuality } from "../models/phrase-quality";

export async function fetchThemes(
  fieldOfStudy: string,
  degree: string,
  alreadySelectedThemes: string[]
): Promise<PhraseQuality[]> {
  const response = await fetch("/api/theme/generate", {
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
  alreadySelectedThemes: string[]
) {
  const response = await fetch("/api/topic/generate", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ fieldOfStudy, degree, alreadySelectedThemes }),
  });
  const responseJson = await response.json();
  return responseJson.themes;
}