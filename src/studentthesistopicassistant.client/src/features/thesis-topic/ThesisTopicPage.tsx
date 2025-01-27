import { useEffect, useState } from "react";
import { FieldOfStudySelector } from "./components/FieldOfStudySelector";
import { DegreeSelector } from "./components/DegreeSelector";
import { CircularSelector } from "./components/CircularSelector";
import { Button, Chip, CircularProgress, Typography } from "@mui/material";
import { PhraseQuality } from "./models/phrase-quality";
import { useMutation } from "react-query";
import { fetchThemes, fetchTopics } from "./services/theme.service";

const maxSelectedThemes = 5;

export function ThesisTopicPage() {
  const [fieldOfStudy, setFieldOfStudy] = useState<string | null>(null);
  const [degree, setDegree] = useState<string | null>(null);
  const [alreadySelectedThemes, setAlreadySelectedThemes] = useState<string[]>(
    []
  );
  const [topics, setTopics] = useState<string[] | null>(null);

  const { mutateAsync: fetchThemesAsync, isLoading: themesLoading } =
    useMutation(() =>
      fetchThemes(fieldOfStudy!, degree!, alreadySelectedThemes)
    );
  const { mutateAsync: fetchTopicsAsync, isLoading: topicsLoading } =
    useMutation(() =>
      fetchTopics(fieldOfStudy!, degree!, alreadySelectedThemes)
    );

  const [choices, setChoices] = useState<string[] | null>(null);

  function updateChoices(choice: string) {
    setAlreadySelectedThemes((prev) => [...prev, choice]);
  }

  async function handleThemeSelection() {
    const response = await fetchThemesAsync();
    setChoices(response.map((x: PhraseQuality) => x.phrase));
  }

  async function prepareTopics() {
    const response = await fetchTopicsAsync();
    setTopics(response.map((x: PhraseQuality) => x.phrase));
  }

  useEffect(() => {
    if (
      fieldOfStudy &&
      degree &&
      alreadySelectedThemes.length < maxSelectedThemes
    ) {
      handleThemeSelection();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [alreadySelectedThemes, degree, fieldOfStudy]);

  return (
    <div className="flex flex-col justify-between p-4">
      <div className="flex flex-col items-center justify-center">
        {fieldOfStudy && (
          <Typography variant="h6" className="text-center">
            Kierunek: {fieldOfStudy}
          </Typography>
        )}
        {degree && (
          <Typography variant="h6" className="text-center">
            Stopień: {degree}
          </Typography>
        )}
        <div className="flex flex-wrap gap-2 p-2 justify-center">
          {alreadySelectedThemes.map((theme) => (
            <Chip key={theme} label={theme} />
          ))}
        </div>
      </div>

      <div className="flex flex-col items-center justify-center">
        {!fieldOfStudy && (
          <FieldOfStudySelector onSelect={(e) => setFieldOfStudy(e)} />
        )}
        {fieldOfStudy && !degree && (
          <DegreeSelector onSelect={(e) => setDegree(e)} />
        )}
        {fieldOfStudy &&
          degree &&
          choices &&
          !themesLoading &&
          alreadySelectedThemes.length < maxSelectedThemes && (
            <CircularSelector
              options={choices}
              onSelect={(e) => updateChoices(e)}
            />
          )}
        {themesLoading && alreadySelectedThemes.length < maxSelectedThemes && (
          <CircularProgress />
        )}
        {fieldOfStudy &&
          degree &&
          alreadySelectedThemes.length >= maxSelectedThemes && (
            <Button onClick={() => prepareTopics()}>Przygotuj tematy</Button>
          )}
        {fieldOfStudy &&
          degree &&
          alreadySelectedThemes.length >= maxSelectedThemes &&
          topics && (
            <div className="flex flex-col gap-2 p-2 text-justify">
              {topics.map((topic) => (
                <Typography key={topic}>{topic}</Typography>
              ))}
            </div>
          )}
        {topicsLoading && alreadySelectedThemes.length >= maxSelectedThemes && (
          <CircularProgress />
        )}
      </div>
    </div>
  );
}
