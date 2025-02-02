import { motion } from "framer-motion";

type Props = {
  size?: "sm" | "md" | "lg";
};

const sizeMap = {
  sm: {
    outer: "w-12 h-12",
    ring: "w-10 h-10",
    inner: "w-8 h-8",
    minDuration: 0.5,
  },
  md: {
    outer: "w-16 h-16",
    ring: "w-14 h-14",
    inner: "w-12 h-12",
    minDuration: 0.75,
  },
  lg: {
    outer: "w-24 h-24",
    ring: "w-20 h-20",
    inner: "w-16 h-16",
    minDuration: 1,
  },
};

export function AiLoader(props: Props) {
  const size = sizeMap[props.size ?? "sm"];

  return (
    <div className="flex flex-col items-center justify-center space-y-4 p-4 relative">
      <div
        className={`relative ${size.outer} flex items-center justify-center`}
      >
        <motion.div
          className={`absolute ${size.inner} rounded-full shadow-2xl`}
          style={{
            background:
              "conic-gradient(from 0deg, #00d4ff, #6a00f4, #ff00ff, #00d4ff)",
            maskImage:
              "radial-gradient(circle, transparent 40%, rgba(0,0,0,1) 50%)",
            WebkitMaskImage:
              "radial-gradient(circle, transparent 40%, rgba(0,0,0,1) 50%)",
            filter: "blur(2px)",
            boxShadow:
              "0px 0px 30px rgba(0, 212, 255, 0.8), 0px 0px 40px rgba(106, 0, 244, 0.6), 0px 0px 50px rgba(255, 0, 255, 0.5)",
          }}
          animate={{ rotate: 360 }}
          transition={{
            repeat: Infinity,
            duration: size.minDuration,
            ease: "linear",
          }}
        />

        <motion.div
          className={`absolute ${size.ring} rounded-full`}
          style={{
            background:
              "conic-gradient(from 0deg, transparent 0deg, #ff00ff 120deg, transparent 240deg)",
            maskImage:
              "radial-gradient(circle, transparent 65%, rgba(0,0,0,1) 70%)",
            WebkitMaskImage:
              "radial-gradient(circle, transparent 65%, rgba(0,0,0,1) 70%)",
          }}
          animate={{ rotate: -360 }}
          transition={{
            repeat: Infinity,
            duration: size.minDuration + 0.5,
            ease: "linear",
          }}
        />

        <motion.div
          className={`absolute ${size.outer} rounded-full`}
          style={{
            background:
              "conic-gradient(from 120deg, transparent 0deg, #00ffff 0deg, transparent 240deg)",
            maskImage:
              "radial-gradient(circle, transparent 65%, rgba(0,0,0,1) 70%)",
            WebkitMaskImage:
              "radial-gradient(circle, transparent 65%, rgba(0,0,0,1) 70%)",
          }}
          animate={{ rotate: 360 }}
          transition={{
            repeat: Infinity,
            duration: size.minDuration + 1,
            ease: "linear",
          }}
        />
      </div>
    </div>
  );
}
