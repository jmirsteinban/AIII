import { CSSValue } from '../../syntax/parser';
import { CSSRadialGradientImage, GradientColorStop, UnprocessedGradientColorStop } from '../image';
export declare const parseColorStop: (args: CSSValue[]) => UnprocessedGradientColorStop;
export declare const processColorStops: (stops: UnprocessedGradientColorStop[], lineLength: number) => GradientColorStop[];
export declare const calculateGradientDirection: (angle: number | [import("../../syntax/tokenizer").NumberValueToken | import("../../syntax/tokenizer").DimensionToken, import("../../syntax/tokenizer").NumberValueToken | import("../../syntax/tokenizer").DimensionToken], width: number, height: number) => [number, number, number, number, number];
export declare const calculateRadius: (gradient: CSSRadialGradientImage, x: number, y: number, width: number, height: number) => [number, number];
