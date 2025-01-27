import { ThesisTopicPage } from "./features/thesis-topic/ThesisTopicPage";
import "./App.scss";
import { AppBar, Toolbar, Typography } from "@mui/material";

export function App() {
  return (
    <div className="h-svh">
      <AppBar position="static">
        <Toolbar className="flex gap-2">
          <img src="/logo.png" className="w-10" />
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Asystent pracy dyplomowej
          </Typography>
        </Toolbar>
      </AppBar>
      <ThesisTopicPage />
    </div>
  );
}
